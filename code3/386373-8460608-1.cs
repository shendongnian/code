    for (int x = 0; x < 80; x++)
    {
        Console.SetCursorPosition(x, 12);
        Console.Write("─");
    }
    for (int y = 0; y < 25; y++)
    {
        Console.SetCursorPosition(40, y);
        Console.Write("|");
    }
    Console.SetCursorPosition(40, 12);
    Console.Write("┼");
