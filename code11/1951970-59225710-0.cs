        class Program
        {
            const int ROWS = 8;
            const int COLS = 8;
            static void Main(string[] args)
            {
                Random rnd = new Random();
                int[] values = Enumerable.Range(0, ROWS * COLS)
                    .Select(x => new { number = x, rand = rnd.Next()})
                    .OrderBy(x => x.rand)
                    .Select(x => x.number).ToArray();
                int[,] T = new int[ROWS, COLS];
                int count = 0;
                for(int row = 0; row < ROWS; row++)
                {
                    for(int col = 0; col < COLS; col++)
                    {
                        T[row, col] = values[count++];
                    }
                }
            }
