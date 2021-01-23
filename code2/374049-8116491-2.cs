    class Program 
    { 
        static void Main(string[] args) 
        { 
            int value1 = 1, value2 = 2, value3 = 1; 
            Console.WriteLine(AllAreEqual<int>(value1, value2, value3));
    
            Console.Write("V2: 1 value ");
            Console.WriteLine(AllAreEqual_V2<int>(1));
    
            Console.Write("V2: no value ");
            Console.WriteLine(AllAreEqual_V2<int>());
    
            Console.Write("V2: 3 values, same ");
            Console.WriteLine(AllAreEqual_V2<int>(1, 1, 1));
    
            Console.Write("V2: 3 values, different ");
            Console.WriteLine(AllAreEqual_V2<int>(1, 1, 2));
    
            Console.Write("V2: 2 values, same ");
            Console.WriteLine(AllAreEqual_V2<int>(1, 1));
    
            Console.Write("V2: 2 values, different ");
            Console.WriteLine(AllAreEqual_V2<int>(1, 2));
    
            Console.ReadKey(); 
        } 
            
        static bool AllAreEqual<T>(params T[] args) 
        { 
            return args.Distinct().ToArray().Length == 1; 
        }
    
        static bool AllAreEqual_V2<T>(params T[] args)
        {
            if (args.Length == 0 || args.Length == 1)
            {
                return true;
            }
    
            if (args.Length == 2)
            {
                return args[0].Equals(args[1]);
            }
    
            T first = args[0];
    
            for (int index = 1; index < args.Length; index++)
            {
                if (!first.Equals(args[index]))
                {
                    return false;
                }
            }
    
            return true;
        }
    }
