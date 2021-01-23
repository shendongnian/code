    using System;
    using System.Text.RegularExpressions;
    
    namespace ReplaceRegex
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine(ReplaceWithX("12345678"));
                Console.WriteLine(ReplaceWithXLeave4("12345678"));
            }
    
            static string ReplaceWithX(string input)
            {
                return Regex.Replace(input, ".", "x");
            }
    
            static string ReplaceWithXLeave4(string input)
            {
                return Regex.Replace(input, ".(?!.{0,3}$)", "x");
            }
        }
    }
