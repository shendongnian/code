    using System;
    
    class Test
    {
        static void Main(string[] args)
        {
            for (int row = 1; row <= 12; row++)
            {
                int zeroBasedRow = row - 1;
                int side = ((zeroBasedRow / 3) % 2) + 1;
                Console.WriteLine("Row {0} goes on side {1}", row, side);
            }
        }
    }
