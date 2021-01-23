    using System;
    using System.Text.RegularExpressions;
    
    class Program
    {
        public static void Main()
        {
            var input = "NXT REPLACES 1 REDISPLAY ITINERARY1CXL-13113654 THANK YOU FOR YOUR INTEREST";
            var match = Regex.Match(input, @"CXL\-(?<number>\d+)\s+");
            if (match.Success)
            {
                Console.WriteLine(match.Groups["number"]);
            }
        }
    }
