    //  1/. Ask for 2table dim sizes.
    Console.WriteLine("Enter number of rows:");
    var x = int.Parse(Console.ReadLine());
    var table = new string[x][];
    // 2/. Fill the board
    for (int row = 0; row < table.GetLength(0); row++)
    {
        Console.WriteLine($"Enter of the line n°{row}");
        var lineSize = int.Parse(Console.ReadLine());
        table[row] = new string[lineSize];
        for (int col = 0; col < table[row].Length; col++)
        {
            Console.WriteLine($"Enter the value of the cell [{row},{col}]");
            table[row][col] = Console.ReadLine();
        }
        Console.Write("\n");
    }
    // 3/. Display the Table 
    Console.Write("\n");
    for (int row = 0; row < table.Length; row++)
    {
        for (int col = 0; col < table[row].Length; col++)
        {
            Console.Write(table[row][col]);
        }
        Console.Write("\n");
    }
