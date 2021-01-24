    using System;
    using System.Text.RegularExpressions;
    
    public class Example
    {
        public static void Main()
        {
            string pattern = @"([a-z]+:)(.*?)([a-z]+:)(.*)";
            string substitution = @"\1 ""redacted""\n\3 ""redacted""";
            string input = @"From: Tom novy <AJames@onmicrosoft.com>
    To: ""mithrandir@wttom.onmicrosoft.com""";
            RegexOptions options = RegexOptions.Singleline | RegexOptions.IgnoreCase;
            
            Regex regex = new Regex(pattern, options);
            string result = regex.Replace(input, substitution);
        }
    }
