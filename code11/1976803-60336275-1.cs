    protected static void ClearAndWriteLine()
    {
        int originalCursorPosition = Console.CursorTop;
        string clear = "\r" + new string(' ', Console.BufferWidth) + "\r";
        Console.Write(clear + "Test");
        Console.SetCursorPosition(0, originalCursorPosition);
    }
