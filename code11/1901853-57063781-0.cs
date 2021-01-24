    using System;
    namespace ConsoleApp17
    {
        public class Summer
        {
            public delegate void EventRaiser();
            public event EventRaiser OnSomethingHappened;
    
            public int Sum(int a, int b)
            {
                int c = a + b;
                if (a != b) // you sophisticated check here
                {
                    OnSomethingHappened();
                }
                return c;
            }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                Summer a = new Summer();
                a.OnSomethingHappened += OnSomethingHandler;
    
                Console.WriteLine($"result = {a.Sum(1, 2)}");
                Console.WriteLine($"result = {a.Sum(2, 2)}");
                Console.ReadKey();
            }
    
            private static void OnSomethingHandler()
            {
                Console.WriteLine("Something happend");
            }
        }
    }
