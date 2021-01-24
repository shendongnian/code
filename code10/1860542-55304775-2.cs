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
                string InvertedTrash = @"[a-zA-Z0-9]";
    
                Output(Source, Trash);
                Console.WriteLine($"{System.Environment.NewLine}Opposite Day!{System.Environment.NewLine}");
                Output(Source, InvertedTrash);
                Console.ReadKey();
            }
            static string TakeOutTheTrash(string Source, string Trash)
            {
                return (new Regex(Trash)).Replace(Source, string.Empty);
            }
            static void Output(string Source, string Trash)
            {
                string Sanitized = TakeOutTheTrash(Source, Trash);
                Console.WriteLine($"Started with: {Source}");
                Console.WriteLine($"Ended with: {Sanitized}");
            }
        }
    }
