    using System;
    using System.Text.RegularExpressions;
    
    public class Example
    {
        public static void Main()
        {
            string pattern = @"(?i)((?:https?:\/\/)?(?:www\.)?[a-z][\w_-]+\S+\.[a-z][\w_-]{1,5})";
            string substitution = @"<a href=""$1"">$1</a>";
            string input = @"Some text www.google.com"" or ""Some text google.com"" subdomain1.subdomain1.subdomain1.google.com 120.101.101.101  google.co Alice X.Y.Z Bob  ";
            RegexOptions options = RegexOptions.Multiline;
            
            Regex regex = new Regex(pattern, options);
            string result = regex.Replace(input, substitution);
        }
    }
