    using System;
    
    class Program
    {
        static void Main(string[] args)
        {
            Func<int, int, int, int> greatest = (x, y, z) => Math.Max(x, Math.Max(y, z));
    
            Console.WriteLine(greatest(1, 2, 3));
            Console.WriteLine(greatest(1, 3, 2));
            Console.WriteLine(greatest(2, 1, 3));
            Console.WriteLine(greatest(2, 3, 1));
            Console.WriteLine(greatest(3, 1, 2));
            Console.WriteLine(greatest(3, 2, 1));
        }
    }
