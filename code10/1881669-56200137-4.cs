    using System;
    using System.Text.RegularExpressions;
    
    public class Example
    {
        public static void Main()
        {
            string pattern = @"^(.*?)([\s:]+)?{([\s\S].*)?.$";
            string substitution = @"$1,$3";
            string input = @"key:{value}
    key:{valu{0}e}
    key:{valu
    {0}e}
    key:   {val-u{0}e}
    key:  {val__[!]
    -u{0}{1}e}";
            RegexOptions options = RegexOptions.Multiline;
            
            Regex regex = new Regex(pattern, options);
            string result = regex.Replace(input, substitution);
        }
    }
