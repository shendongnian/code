    using System;
    
    namespace ConsoleApp1
    {
        internal class Program
        {
            private static void Main(string[] args)
            {
                MethodA(null);
                MethodA(default);
                MethodA(new int?());
                MethodA(5);
    
                Console.WriteLine();
    
                MethodB();
                MethodB(null);
                MethodB(default);
                MethodB(new int?());
                MethodB(5);
    
                Console.WriteLine();
    
                MethodC();
                MethodC(null);
                MethodC(default);
                MethodC(new int?());
                MethodC(5);
    
                Console.WriteLine();
    
                MethodD();
                MethodD(null);
                MethodD(default);
                MethodD(new int?());
                MethodD(5);
            }
    
            private static void MethodA(int? x)
            {
                Console.WriteLine($"MethodA({x?.ToString() ?? "null"})");
    
                if (x == null)
                    Console.WriteLine($"x is null");
                else if (!x.HasValue)
                    Console.WriteLine($"x is not null, but an integer value is not set on it");
                else
                    Console.WriteLine($"x is not null, and its integer value is '{x.Value}'");
    
                int x2 = x ?? 10;
                Console.WriteLine($"x2 = {x2}");
            }
    
            public static void MethodB(int? x = 10)
            {
                Console.WriteLine($"MethodB({x?.ToString() ?? "null"})");
    
                if (x == null)
                    Console.WriteLine($"x is null");
                else if (!x.HasValue)
                    Console.WriteLine($"x is not null, but an integer value is not set on it");
                else
                    Console.WriteLine($"x is not null, and its integer value is '{x.Value}'");
            }
    
            public static void MethodC(int? x = null)
            {
                Console.WriteLine($"MethodC({x?.ToString() ?? "null"})");
    
                if (x == null)
                    Console.WriteLine($"x is null");
                else if (!x.HasValue)
                    Console.WriteLine($"x is not null, but an integer value is not set on it");
                else
                    Console.WriteLine($"x is not null, and its integer value is '{x.Value}'");
            }
    
            public static void MethodD(int? x = default)
            {
                Console.WriteLine($"MethodD({x?.ToString() ?? "null"})");
    
                if (x == null)
                    Console.WriteLine($"x is null");
                else if (!x.HasValue)
                    Console.WriteLine($"x is not null, but an integer value is not set on it");
                else
                    Console.WriteLine($"x is not null, and its integer value is '{x.Value}'");
            }
        }
    }
