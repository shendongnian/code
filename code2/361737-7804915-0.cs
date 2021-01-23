    using System;
    using System.Text.RegularExpressions;
    
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = 
            {
                @"XXXX       c:\mypath1\test",
                @"YYYYYYY             c:\this is other path\longer",
                @"ZZ        c:\mypath3\file.txt"
            };
            
            foreach (string line in lines)
            {
                Console.WriteLine(ExtractPathFromLine(line));
            }
        }
        
        static readonly Regex PathRegex = new Regex(@"^[^ \t]+[ \t]+(.*)$");
        
        static string ExtractPathFromLine(string line)
        {
            Match match = PathRegex.Match(line);
            if (!match.Success)
            {
                throw new ArgumentException("Invalid line");
            }
            return match.Groups[1].Value;
        }    
    }
