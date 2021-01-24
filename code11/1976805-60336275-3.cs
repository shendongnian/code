    protected static void ClearAndWriteLine()
    {
        int originalCursorPosition = Console.CursorTop;
        Console.SetCursorPosition(0, Console.CursorTop);
        Console.Write(new string(' ', Console.WindowWidth));
        Console.SetCursorPosition(0, Console.CursorTop);
    
        Random rnd = new Random();
        char randomChar = (char)rnd.Next('a', 'z');
        Console.Write(new string(randomChar, rnd.Next(10, 50)));
        Console.SetCursorPosition(0, originalCursorPosition);
    }
