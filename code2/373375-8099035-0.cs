    using System;
    
    class Program
    {
        static void Foo(int x)
        {
            Console.WriteLine("int!");
        }
        
        static void Foo(string x)
        {
            Console.WriteLine("string!");
        }
        
        static void Main(string[] args)  
        {
            dynamic d = 10;
            Foo(d);
        }
    }
