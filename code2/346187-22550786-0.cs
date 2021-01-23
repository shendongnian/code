    using System;
    
    static class Program
    {
    	public static void Main()
    	{
            Console.WriteLine("Constant={0}", Problem.Constant);
            Console.WriteLine("ReadOnly={0}", Problem.ReadOnly);
            Console.WriteLine("Field={0}", Problem.Field);
            Console.WriteLine("Property={0}", Problem.Property);
    	}
    
        private static class Problem
        {
            public const int Constant = 1;
            public static readonly int ReadOnly = 2;
            public static int Field = 3;
            private static int mProperty = 4;
            public static int Property { get { return mProperty; } }
            
            static Problem()
            {
                Console.WriteLine("Problem: static initializer");
            }
        }
    }
