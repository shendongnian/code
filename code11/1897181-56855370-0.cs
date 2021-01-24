    using System;
    using System.Text.RegularExpressions;
    
    public class Example
    {
        public static void Main()
        {
            string pattern = @"""([^""]+?)\s+\|\s+([^""]+?)""";
            string substitution = @"\1 \2";
            string input = @"""Hello""|""Green | Blue""|123.45|""""|""""|""""|5|45";
            RegexOptions options = RegexOptions.Multiline;
            
            Regex regex = new Regex(pattern, options);
            string result = regex.Replace(input, substitution);
        }
    }
