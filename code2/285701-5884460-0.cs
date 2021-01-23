    using System;
    namespace ConsoleApplication5 
    {
        class Program 
        {
            private static readonly Random _random = new Random();
            static void Main() 
            {
                for (int i = 0; i < 100; i++)
                    Console.WriteLine(_random.Next(int.MaxValue));
                Console.ReadLine();
            }
        }
    }
