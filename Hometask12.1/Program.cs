List<string> toDoList = new List<string>();

List<bool> isDone = new List<bool>();

Modes mode = Modes.Input;

Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine("\tTO-DO LIST");
Console.ResetColor();

do
{
    switch (mode)
    {
        case Modes.Input:            
            Console.WriteLine("\nEnter the task that you want to add:");
            AddTask(Console.ReadLine(), toDoList, isDone);
            break;
        case Modes.Remove:
            Console.WriteLine("\nEnter the number of task you'd like to remove:");
            RemoveTask(Console.ReadLine(), toDoList, isDone);
            break;
        default:
            Console.WriteLine("\nEnter the number of task you'd like to tag as done:");
            DoneTag(Console.ReadLine(), isDone);
            break;
    }
    Console.Clear();
    ListOutput(toDoList, isDone);

    int modeNumber = -1;
    do
    {
        // Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\nEnter <0> if you want to add the task," +
            "\n<1> if you want to remove the task," +
            "\n<2> if you want to tag the task as done," +
            "\n<3> if you want to exit.");
        // Console.ResetColor();
        modeNumber = ModeSelection(Console.ReadLine());

        if (modeNumber != -1)
        {
            mode = (Modes)modeNumber;
        }
        else
            Console.WriteLine("\nIncorrect input!");
    }
    while (modeNumber == -1);
}
while (mode != Modes.Exit);

static void AddTask(string task, List<string> toDoList, List<bool> isDone)
{
    toDoList.Add(task);
    isDone.Add(false);
}

static void RemoveTask(string input, List<string> toDoList, List<bool> isDone)
{
    byte number;
    if (byte.TryParse(input, out number) &&
        number > 0 &&
        number <= toDoList.Count)
    {
        toDoList.RemoveAt(number - 1);
        isDone.RemoveAt(number - 1);
    }
    else
    {
        Console.WriteLine("\nIncorrect input!");
        Console.ReadLine();
    }
}

static void DoneTag(string input, List<bool> isDone)
{
    byte number;
    if (byte.TryParse(input, out number) &&
        number > 0 &&
        number <= isDone.Count)
        isDone[number - 1] = true;
    else
    {
        Console.WriteLine("\nIncorrect input!");
        Console.ReadLine();
    }
}

static void ListOutput(List<string> toDoList, List<bool> isDone)
{
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("\tTO-DO LIST");
    for (byte i = 0; i < toDoList.Count; i++)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine(isDone[i]
            ? $"{i + 1}. ✅ {toDoList[i]}"
            : $"{i + 1}. {toDoList[i]}");
    }
    Console.ResetColor();
}

static int ModeSelection(string input)
{
    if (int.TryParse(input, out int modeNumber) &&
        Enum.IsDefined(typeof(Modes), modeNumber))
    {
        return modeNumber;
    }
    else
        return -1;
}
