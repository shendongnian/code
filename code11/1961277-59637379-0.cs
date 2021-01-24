    public class BufferedConsole
    {
        private class Cell
        {
            public char Pixel;
            public ConsoleColor ForegroundColor;
            public ConsoleColor BackgroundColor;
        }
        static private Cell[,] _buffer = new Cell[80, 25];
        static BufferedConsole()
        {
            Clear();
        }
        static void Clear()
        {
            for (int row = 0; row < 25; row++)
            {
                for (int col = 0; col < 80; col++)
                {
                    _buffer[col, row] = new Cell
                    {
                        ForegroundColor = ConsoleColor.Black,
                        BackgroundColor = ConsoleColor.Black,
                        Pixel = '?'
                    };
                    
                }
            }
            Refresh();
        }
        public static void Plot(int x, int y, char pixel, ConsoleColor foreColor, ConsoleColor backColor)
        {
            var cell = _buffer[x, y];
            cell.Pixel = pixel;
            cell.ForegroundColor = foreColor;
            cell.BackgroundColor = backColor;
        }
        public static void Refresh()
        {
            Console.SetCursorPosition(0, 0);
            ConsoleColor lastForeColor = ConsoleColor.White;
            ConsoleColor lastBackColor = ConsoleColor.Black;
            Console.CursorVisible = false;
            for (var row = 0; row < 25; row++)
            {
                for (var col = 0; col < 80; col++)
                {
                    var cell = _buffer[col, row];
                    if (lastForeColor != cell.ForegroundColor)
                    {
                        Console.ForegroundColor = cell.ForegroundColor;
                        lastForeColor = cell.ForegroundColor;
                    }
                    if (lastBackColor != cell.BackgroundColor)
                    {
                        Console.BackgroundColor = cell.BackgroundColor;
                        lastBackColor = cell.BackgroundColor;
                    }
                    Console.Write(cell.Pixel);
                }
                Console.WriteLine();
            }
            Console.CursorVisible = true;
        }
    }
