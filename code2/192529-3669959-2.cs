    using System;
    using System.Text.RegularExpressions;
    
    class Program
    {
        private static readonly Regex Pattern = new Regex
            (@"\\(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}" +
             @"(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\\");
            
    
        static void Main(string[] args)
        {
            Console.WriteLine(ContainsAddress("Bad IP \\400.100.100.100\\ xyz"));
            Console.WriteLine(ContainsAddress("Good IP \\200.255.123.100\\ xyz"));
            Console.WriteLine(ContainsAddress("No IP \\but slashes\\ xyz"));
            Console.WriteLine(ContainsAddress("Long IP \\123.100.100.100.100\\ x"));
        }
     
        static bool ContainsAddress(string line)
        {
            return Pattern.IsMatch(line);        
        }
    }
