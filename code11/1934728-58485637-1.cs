    public static void Main(string[] args)
    {
        // Get a 10x10 grid with random mines
        var mines = MinesSetter(10, 10);
        // Display the grid (with mines visible)
        for (int row = 0; row < mines.GetLength(0); row++)
        {
            for (int col = 0; col < mines.GetLength(1); col++)
            {
                Console.Write(mines[row, col] + " ");
            }
            Console.WriteLine();
        }
        Console.ReadLine();
    }
