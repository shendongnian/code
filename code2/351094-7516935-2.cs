    using System;
    
    class Test
    {
        static void Main(string[] args)
        {
            object x = CreateAction();
            object y = CreateAction();
            Console.WriteLine(x == y);
        }
        static Action CreateAction()
        {
            return () => Console.WriteLine("Hello");
        }
    }
