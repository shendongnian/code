    using System;
    using System.Text.RegularExpressions;
    
    public class Example
    {
        public static void Main()
        {
            string pattern = @"(?=^|\r?\n)\bTEXT\b";
            string substitution = @"MTEXT";
            string input = @"TEXT Some data before TEXT some data after
    
    TEXTY Some data before  TEXT 
    
    TEXT Some data before TEXT some data after
    
    TEXT Some data before  TEXT NOTTEXT ";
            RegexOptions options = RegexOptions.Multiline;
            
            Regex regex = new Regex(pattern, options);
            string result = regex.Replace(input, substitution);
        }
    }
