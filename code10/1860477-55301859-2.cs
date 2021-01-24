    // 3/. Display the Table 
    Console.Write("\n");
    for (int row = 0; row < table.GetLength(0); row++)
    {
        for (int col = 0; col < table.GetLength(1); col++)
        {
            Console.Write(table[row, col]);
        }
        Console.Write("\n");
    }
