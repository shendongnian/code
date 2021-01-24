    using System;
    using System.Text.RegularExpressions;
    
    public class Example
    {
        public static void Main()
        {
            string pattern = @"-?[0-9]*(?:\.?[0-9]+)?(?:[eE][-+]?[0-9]+)?";
            string input = @"0.085+4.346*10^-5*((a^2)-(0^2))+0.0017228*(a-(0)))*2
    0.208+0*d^3-0.00000434*d^2-0.00203*d)*2)";
            RegexOptions options = RegexOptions.Multiline;
            
            foreach (Match m in Regex.Matches(input, pattern, options))
            {
                Console.WriteLine("'{0}' found at index {1}.", m.Value, m.Index);
            }
        }
    }
