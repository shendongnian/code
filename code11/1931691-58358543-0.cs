    using System;
    using System.Text.RegularExpressions;
    
    public class Example
    {
        public static void Main()
        {
            string pattern = @"@[^:]+";
            string substitution = @"";
            string input = @"somename@somedomain.com:hello_world1
    somename@some_other_domain.com:hello_world2";
            RegexOptions options = RegexOptions.Multiline;
            
            Regex regex = new Regex(pattern, options);
            string result = regex.Replace(input, substitution);
        }
    }
