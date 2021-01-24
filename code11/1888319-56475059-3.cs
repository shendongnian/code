    static void Main(string[] args)
    {
        var d3 = new int[,,]
        {
            { { 1, 2 }, { 3, 4 }, {5,6 }, {7,8 } },
            { { 9, 10}, { 11, 12},{ 13,14} , {15,16 }},
            { { 17, 18}, { 19, 20},{ 21,22}, {23,24 } }
        };
        Console.WriteLine("Original:");
        Print3DArray(d3);
        var flat = d3.Cast<int>().ToArray();
        Console.WriteLine("Flat:");
        Console.WriteLine(string.Join(" ", flat));
        var size = new[] { d3.GetLength(0), d3.GetLength(1), d3.GetLength(2) };
        var expanded = Expand(flat, size);
        Console.WriteLine("Expanded:");
        Print3DArray(expanded);
    }
    static void Print3DArray(int[,,] array)
    {
        Console.WriteLine("{");
        for(int i = 0; i< array.GetLength(0);i++)
        {
            Console.Write("    {");
            for (int j=0;j<array.GetLength(1);j++)
            {
                Console.Write(" {");
                for (int k=0;k<array.GetLength(2);k++)
                {
                    Console.Write($" {array[i, j, k]}");
                }
                Console.Write(" }");
            }
            Console.WriteLine(" }");
        }
        Console.WriteLine("}");
    }
