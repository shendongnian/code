    private static char[,] GetInitialArray()
    {
        var initialArray = new char[4, 5];
        for (var row = 0; row <= initialArray.GetUpperBound(0); row++)
        {
            for (var col = 0; col <= initialArray.GetUpperBound(1); col++)
            {
                if ((row == 1 && col == 2) || (row == 3 && col == 4))
                {
                    initialArray[row, col] = '.';
                }
                else
                {
                    initialArray[row, col] = '*';
                }
            }
        }
        return initialArray;
    }
    private static void PrintArrayToConsole(char[,] input)
    {
        if (input == null) return;
        for (var row = 0; row <= input.GetUpperBound(0); row++)
        {
            for (var col = 0; col <= input.GetUpperBound(1); col++)
            {
                Console.Write(input[row, col]);
            }
            Console.WriteLine();
        }
    }
    private static void WriteHeader(string headerText)
    {
        if (string.IsNullOrEmpty(headerText))
        {
            Console.Write(new string('═', Console.WindowWidth));
            return;
        }
        Console.WriteLine('╔' + new string('═', headerText.Length + 2) + '╗');
        Console.WriteLine($"║ {headerText} ║");
        Console.WriteLine('╚' + new string('═', headerText.Length + 2) + '╝');
    }
