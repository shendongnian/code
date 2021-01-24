    private static void Main(string[] args)
    {
        int[] testInts = { 1, 2, 3, 4, 5 };
        testInts =  testInts.Append(6);
        Console.WriteLine("Test Integers\n");
        foreach (int variable in testInts)
        {
            Console.WriteLine(Convert.ToString(variable));
        }
        Console.WriteLine("\nPress any key to continue.");
        Console.ReadKey();
    }
    
    public static int[] Append(this int[] arr, int value)
    {
        arr = arr.Concat(new[] { value }).ToArray();
        return arr;
    }
