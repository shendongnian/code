    using System;
    
    namespace ChildConsoleApp
    {
        internal static class Program
        {
            public static void Main()
            {
                Console.WriteLine("Hi");
    
                string text; // Echo all input
                while ((text = Console.ReadLine()) != "stop")
                    Console.WriteLine("Echo: " + text);
    
                Console.WriteLine("Stopped.");
            }
        }
    }
