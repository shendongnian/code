    static void Print3DArray(int[,,] array)
    {
        Console.WriteLine("{");
        for (int i = 0; i < array.GetLength(0); i++)
        {
            Console.Write("    {");
            for (int j = 0; j < array.GetLength(1); j++)
            {
                Console.Write(" {");
                for (int k = 0; k < array.GetLength(2); k++)
                {
                    Console.Write($" {array[i, j, k]}");
                }
                Console.Write(" }");
            }
            Console.WriteLine(" }");
        }
        Console.WriteLine("}");
    }
