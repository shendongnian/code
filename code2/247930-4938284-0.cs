    using System;
    
    class Program {
        static void Main(string[] args) {
            var colorName = Console.ReadLine();
            try {
                ConsoleColor color = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), colorName, true);
                Console.ForegroundColor = color;
                Console.WriteLine("Okay");
            }
            catch (ArgumentException ex) {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }
    }
