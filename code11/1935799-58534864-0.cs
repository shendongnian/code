    using System;
    using System.Text.RegularExpressions;
    namespace SyntaxTest
    {
        class Program
        {
    
            static void Main(string[] args)
            {
                var input =
                    "these all are strings, 000_00_0 and more strings are there I have here 649_17_8, and more with this format 975_63_7.";
                var pattern = "..._.._.";
    
                Match result = Regex.Match(input, pattern);
                if (result.Success)
                {
                    while (result.Success)
                    {
                        Console.WriteLine("Match: {0}", result.Value);
                        result = result.NextMatch();
                    }
    
                    Console.ReadLine();
                }
            }
    
        }
    }
