    using System;
    using System.Text.RegularExpressions;
    
    namespace ConsoleApp
    {
        class Program
        {
            static void Main(string[] args)
            {
                string Source = @"H)*e/.?l\l{}*o ][W!~`@#""or^-_=+ld!";
                string Trash = @"[^a-zA-Z0-9]";
                Regex rgx = new Regex(Trash);
    
                //Take out the trash!
                string Result = rgx.Replace(Source, "");
    
                Console.WriteLine($"Started with: {Source}");
                Console.WriteLine($"Ended with: {Result}");
    
                Console.ReadKey();
            }
        }
    }
