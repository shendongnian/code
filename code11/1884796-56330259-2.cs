    using System;
    using System.Text.RegularExpressions;
    public class Example
    {
        public static void Main()
        {
            string pattern = @"(.+=)?(.+?)(?:;.+)";
            string substitution = @"$2";
            string input = @"word1=word2;word3
    word2;word3";
            RegexOptions options = RegexOptions.Multiline;
            
            Regex regex = new Regex(pattern, options);
            string result = regex.Replace(input, substitution);
        }
    }
