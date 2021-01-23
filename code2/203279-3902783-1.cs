    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    
    namespace TokenReplacement
    {
        class Program
        {
            static void Main(string[] args)
            {
                string text = "this is a example of my text that I want to change <#somevalue#> and <#anothervalue#>";
    
                var tokens = new Dictionary<string, string>
                {
                    { "somevalue", "Foo" },
                    { "anothervalue", "Bar" }
                };
    
                Console.WriteLine(Replace(text, tokens));
            }
    
            static string Replace(string input, Dictionary<string, string> tokens)
            {
                MatchEvaluator evaluator = match =>
                {
                    string token;
                    if (tokens.TryGetValue(match.Groups[1].Value, out token))
                        return token;
    
                    return match.Value;
                };
    
                return Regex.Replace(input, "<#(.*?)#>", evaluator);
            }
        }
    }
