    using System;
    using System.Text.RegularExpressions;
    
    public class Test
    {
        public static void Main()
        {
            string pattern = @"(?s)\s*\[\s*\b(?:see|note|ant|restr|syn)\b\s*=[^\]]*\]";
            string substitution = @"";
            string input = @"[2][n]
              shutter; window shutter
            
            ,と|戸,1266970,(Y, 5, 3, Y, [1][n]
              [restr=戸]
              door (esp. Japanese-style)";
            Regex regex = new Regex(pattern);
            string result = regex.Replace(input, substitution);
            Console.WriteLine(result);
        }
    }
