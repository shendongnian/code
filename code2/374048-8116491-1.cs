    class Program
    {
        static void Main(string[] args)
        {
            int value1 = 1, value2 = 2, value3 = 1;
            Console.WriteLine(AllAreEqual<int>(value1, value2, value3));
            Console.ReadKey();
        }
    
        static bool AllAreEqual<T>(params T[] args)
        {
            return args.Distinct().ToArray().Length == 1;
        }
    }
