    using System;
    using System.Text.RegularExpressions;
    
    public class Example
    {
        public static void Main()
        {
            string pattern = @"\s*\[\s*\b(?:see|note|ant|restr|syn)\b\s*=[^\]\r\n]*\]";
            string substitution = @"";
            string input = @"[2][n]
              shutter; window shutter
            
            ,と|戸,1266970,(Y, 5, 3, Y, [1][n]
              [restr=戸]
              door (esp. Japanese-style)";
            RegexOptions options = RegexOptions.Singleline;
            
            Regex regex = new Regex(pattern, options);
            string result = regex.Replace(input, substitution);
            Console.WriteLine(result);
        }
    }
