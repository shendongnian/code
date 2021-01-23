    int X;
    String Result = Console.Readline();
    while(!Int32.TryParse(Result, out X))
    {
    Console.WriteLine("Not a valid number, try again.");
    Result = Console.Readline();
    }
