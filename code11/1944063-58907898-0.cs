    using System;
    
    namespace consoleapp
    {
        class Program
        {
            static void Main(string[] args)
            {
                System.Console.WriteLine("Enter your name: ");
                var name = Console.ReadLine();
                Console.WriteLine($"Hello {name}");
            }
        }
    }
