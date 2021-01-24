    private static void Main(string[] args)
    {
        var slots = new int[4, 3];
        for (int i = 0; i < 12; i++)
        {
            var col = i / 4;
            var row = i % 4;
            slots[row, col] = i + 1;
        }
        for (int row = 0; row <= slots.GetUpperBound(0); row++) 
        {
            for (int col = 0; col <= slots.GetUpperBound(1); col++)
            {
                Console.Write($" {slots[row, col]}");
            }
            Console.WriteLine();
        }
        // Ask the user to select a number from the grid
        var chosenNumber = GetIntFromUser("\nSelect a number: ", x => x > 0 && x < 13);
        // Get the coordinates of that selected number
        var selCol = (chosenNumber - 1) / 4;
        var selRow = (chosenNumber - 1) % 4;
        // Print the grid, highlighting their 
        // selected number and it's neighbors
        Console.WriteLine();
        for (int row = 0; row <= slots.GetUpperBound(0); row++)
        {
            for (int col = 0; col <= slots.GetUpperBound(1); col++)
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
