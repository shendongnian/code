    public static void plotLine(int x0, int y0, int x1, int y1)
    {
        int dx = x1 - x0;
        int dy = y1 - y0;
        int D = 2 * dy - dx;
        int y = y0;
        for (int x = x0; x <= x1; x++)
        {
            Console.SetCursorPosition(x, y);
            Console.Write('o');
            if (D > 0)
            {
                y = y + 1;
                D = D - 2 * dx;
            }
            D = D + 2 * dy;
        }
    }
