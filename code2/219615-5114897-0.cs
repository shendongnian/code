    using System;
    namespace ConsoleApplication1
    {
        public class Program
        {
            static void Main(string[] args)
            {
                PrintMessage();
                Console.Write("Press any key to continue . . . ");
                Console.ReadKey(true);
                Console.WriteLine();
            }
    
            public static void PrintMessage()
            {
                Console.WriteLine("MESSAGE!");
            }
        }
    }
