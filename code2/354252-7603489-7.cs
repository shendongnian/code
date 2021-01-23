    Console.WriteLine("static byte[,] LookupTable = new byte[128,7] {");
    for (int i = 0; i < 128; ++i)
    {
        Console.Write("    {");
        for (int j = 0; j < 7; ++j)
        {
            if (j > 0)
            {
                Console.Write(",");
            }
            Console.Write(" {0}", LookupTable[i, j]);
        }
        Console.WriteLine(" },");
    }
    Console.WriteLine("};");
