    using System;
    using System.Text.RegularExpressions;
    
    public class Example
    {
        public static void Main()
        {
            string pattern = @"(.*""[^,]*),([^,]*"".*)";
            string substitution = @"\1 \2";
            string input = @"-1299-5,""XXX,XXXX"",trft,4,0,10800";
            RegexOptions options = RegexOptions.Multiline;
            
            Regex regex = new Regex(pattern, options);
            string result = regex.Replace(input, substitution);
        }
    }
