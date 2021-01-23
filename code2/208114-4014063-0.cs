    using System;
    
    class Test
    {
        static void Main()
        {
            Foo<int>(5); // Works
            Foo<int>(); // Compile-time error
            Foo<string>();
        }
        
        static void Foo<T>(int x = 0)
            where T : struct
        {
            Console.WriteLine("where T : struct");
        }
        
        static void Foo<T>()
            where T : class
        {
            Console.WriteLine("where T : class");
        }
    }
