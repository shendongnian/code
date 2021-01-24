    private static void Main(string[] args)
    {
        var rowCount = 4;
        var colCount = 3;
        var slots = new int[rowCount, colCount];
        for (int i = 0; i < rowCount * colCount; i++)
        {
            var col = i / rowCount;
            var row = i % rowCount;
            slots[row, col] = i + 1;
        }
        for (int row = 0; row < rowCount; row++)
        {
            for (int col = 0; col < colCount; col++)
            {
                Console.Write($" {slots[row, col]}");
            }
            Console.WriteLine();
        }
        // Ask the user to select a number from the grid
        var chosenNumber = GetIntFromUser("\nSelect a number: ", 
            x => x > 0 && x < rowCount * colCount);
        // Get the coordinates of that selected number
        var selCol = (chosenNumber - 1) / 4;
        var selRow = (chosenNumber - 1) % 4;
        // Print the grid, highlighting their 
        // selected number and it's neighbors
        Console.WriteLine();
        for (int row = 0; row < rowCount; row++)
        {
            for (int col = 0; col < colCount; col++)
            {
                if (row == selRow && col == selCol)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else if (row >= selRow - 1 && row <= selRow + 1 &&
                         col >= selCol - 1 && col <= selCol + 1)
                {
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Blue;
                }
                else
                {
                    Console.ResetColor();
                }
                Console.Write($" {slots[row, col]}");
            }
            Console.WriteLine();
        }
        GetKeyFromUser("\nDone! Press any key to exit...");
    }
