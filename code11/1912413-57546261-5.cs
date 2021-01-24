    public static void LineDiaglonal(int x, int y, int length)
    {
        for (var i = 0; i < length; i++)
        {
            Console.SetCursorPosition(x + i, y + i);
            Console.Write('\\');
        }
    }
