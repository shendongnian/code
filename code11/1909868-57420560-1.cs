    using System;
    using System.Threading.Tasks;
    
    class Program
    {
        static void Test()
        {
            Console.WriteLine("Test");
        }
    
        static void Test2()
        {
            Console.WriteLine("Test2");
        }
    
        static void Test3()
        {
            Console.WriteLine("Test3");
        }
    
        static void Main()
        {
            Parallel.Invoke(Test, Test2, Test3);
            Console.WriteLine("[INTERMEDIATE]");
            Parallel.Invoke(Test, Test2, Test3);
        }
    }
