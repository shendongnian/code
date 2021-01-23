    using System;
    
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("You are speaking {0}",
                System.Globalization.CultureInfo.CurrentCulture.EnglishName);
            Console.ReadLine();
        }
    }
