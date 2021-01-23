    public static void Main()
    {
        var hey = new string[,,] {
            {
                { "000", "001", "002" },
                { "010", "011", "012" },
                { "020", "021", "022" },
            },
            {
                { "100", "101", "102" },
                { "110", "111", "112" },
                { "120", "121", "122" },
            },
            {
                { "200", "201", "202" },
                { "210", "211", "212" },
                { "220", "221", "222" },
            },
        };
    
        for (int x = 0; x < 3; x++)
        {
            for (int y = 0; y < 3; y++)
            {
                for (int z = 0; z < 3; z++)
                {
                    Console.WriteLine("{0}{1}{2} = {3}", x, y, z, hey[x, y, z]);
                }
                Console.WriteLine();
                Console.WriteLine();
            }
    
            Console.WriteLine();
        }
    
        Console.ReadLine();
    }
