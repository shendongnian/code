    static void PrintRandomNumberArrayValues(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        { 
            Console.WriteLine("{0}", array[i]);
        }
        Console.WriteLine();
    }
    static void Main()
    {
        PopulateRandomNumberArrays();
        PrintRandomNumberArrayValues(randomNumberArray0);
        PrintRandomNumberArrayValues(randomNumberArray1);
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
