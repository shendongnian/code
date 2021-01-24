    using System;
    using System.Text.RegularExpressions;
    
    public class Example
    {
        public static void Main()
        {
            string pattern = @"(?<=""genre"":\s\[)([^\]]*)(?=])";
            string input = @"""genre"": [
        ""Action"",
        ""Sci-Fi""
      ],
    
    ""notgenre"": [
        ""Action"",
        ""Sci-Fi""
      ],
    
    ""genre"": [
        ""Action"",
        ""Sci-Fi""
      ],";
            RegexOptions options = RegexOptions.Singleline;
            
            foreach (Match m in Regex.Matches(input, pattern, options))
            {
                Console.WriteLine("'{0}' found at index {1}.", m.Value, m.Index);
            }
        }
    }
