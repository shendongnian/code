    using System;
    using System.Text.RegularExpressions;
    
    public class Example
    {
        public static void Main()
        {
            string pattern = @"<(.+)>([0-9-\s()+]+)<\/(.+)>";
            string substitution = @"$2";
            string input = @"<div id=""Only456"">(555) 555-1212</div>
    <h1>+1 800 555-1212</h1>
    <span class=""row"">555-555-1212</span>";
            RegexOptions options = RegexOptions.Multiline;
            
            Regex regex = new Regex(pattern, options);
            string result = regex.Replace(input, substitution);
        }
    }
