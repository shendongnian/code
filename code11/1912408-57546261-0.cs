        public static void LineHorizontale(int x, int y, int height)
        {
            for (var i = 0; i < height; i++)
            {
                Console.SetCursorPosition(x, y + i);
                Console.WriteLine("│");
            }
        }
