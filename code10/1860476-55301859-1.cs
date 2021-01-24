    // 2/. Fill the board
    for (int row = 0; row < table.GetLength(0); row++)
    {
        for (int col = 0; col < table.GetLength(1); col++)
        {
            Console.WriteLine($"Enter the value of the cell [{row},{col}]");
            table[row, col] = Console.ReadLine();
        }
    }
