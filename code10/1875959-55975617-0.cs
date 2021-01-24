    using System;
    using System.Linq;
    using System.Reflection;
    
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Foo(1, 2, 3, 4, 5));  //outputs 15
        }
    
        public static int Foo(params int[] args)
        {
            return (int)typeof(Program).GetMethod(nameof(Bar), BindingFlags.Public | BindingFlags.Static).Invoke(null, args.Select(v => (object)v).ToArray());
        }
    
        public static int Bar(int a, int b, int c, int d, int e)
        {
            return a + b + c + d + e;
        }
    }
