    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using System.Globalization;
    
    namespace ConsoleApp
    {
        class Program
        {
            static void Main(string[] args)
            {
                var strings = GetSamples();
                var highestNumber =  strings.Select(s => int.Parse(Regex.Match(s, @"\d+").Value, NumberFormatInfo.InvariantInfo)).Max();
                Console.WriteLine(highestNumber);
            }
    
            public static IEnumerable<String> GetSamples()
            {
                yield return "AG000104";
                yield return "AG000176";
                yield return "AG000296";
                yield return "AG000201";
            }
        }
    }
