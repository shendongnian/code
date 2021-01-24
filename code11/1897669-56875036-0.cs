    using System;
    using System.Text.RegularExpressions;
    
    public class Example
    {
        public static void Main()
        {
            string pattern = @"{Container:.*?\s*([^\s]+)\s*·.*";
            string substitution = @"$1";
            string input = @"{Container: randomname Running · random# GPM · randomitem}
    {Container: Jake Running · 56 GPM · Beans}
    {Container: Jake-Some-other-name Running · 56 GPM · Beans}
    {Container: Jake-Some-other-name     Running     · 56 GPM · Beans}";
            RegexOptions options = RegexOptions.Multiline;
            
            Regex regex = new Regex(pattern, options);
            string result = regex.Replace(input, substitution);
        }
    }
  
