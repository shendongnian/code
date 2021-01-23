    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    static class Program {
        static void Main() {
            string test = "{Welcome to {stackoverflow}. This is a question C#}";
            // get whatever is not a '{' between braces, non greedy
            Regex regex = new Regex("{([^{]*?)}", RegexOptions.Compiled);
            // the contents found
            List<string> contents = new List<string>();
            // flag to determine if we found matches
            bool matchesFound = false;
            // start finding innermost matches, and replace them with their 
            // content, removing braces
            do {
                matchesFound = false;
                // replace with a MatchEvaluator that adds the content to our
                // list.
                test = regex.Replace(test, (match) => { 
                    matchesFound = true;
                    var replacement = match.Groups[1].Value;
                    contents.Add(replacement);
                    return replacement; 
                });
            } while (matchesFound);
            foreach (var content in contents) {
                Console.WriteLine(content);
            }
        }
    }
