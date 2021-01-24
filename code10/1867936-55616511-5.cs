    using System.IO;
    using System.Linq;
    using HtmlAgilityPack;
    using System.Text.RegularExpressions;
    using System.Diagnostics;
    using System.Collections.Generic;
    using System;
    
    namespace SoQuestion
    {
        class Program
        {
            // private static string phoneReg = @"[\+]{0,1}(\d{10,13}|[\(][\+]{0,1}\d{2,}[\13)]*\d{5,13}|\d{2,6}[\-]{1}\d{2,13}[\-]*\d{3,13})";
    
            private static string phoneReg = @"\s+\d[ \d]+\r\n.+\r\n";
    
            private static Regex phoneRegex = new Regex(phoneReg, RegexOptions.IgnoreCase);
            public static void Main(string[] args)
            {
                HtmlDocument doc = new HtmlDocument();
                doc.Load(@"C:\temp\HTMLPage1.html");
                doc.DocumentNode.Descendants()
                                .Where(n => n.Name == "script" || n.Name == "style" || n.Name == "svg" || n.Name == "button"
                                      || n.Name == "li" || n.Name == "link" || n.Name == "img" || n.Name == "head" || n.Name == "header" || n.Name == "input")
                                .ToList()
                                .ForEach(n => n.Remove());
                var phoneMatches = phoneRegex.Matches(doc.DocumentNode.InnerText);
    
                List<Tuple<string, string>> data = new List<Tuple<string, string>>();
    
                ApplyForEachItem(phoneMatches, match =>
                {
                    int indexFirstDigit = match.Value.IndexOfAny(new char[]{'1', '2', '3', '4', '5', '6', '7', '8', '9', '0' });
    
                    string[] phoneAndDesc = match.Value.Substring(indexFirstDigit).Split("\r\n");
                    data.Add(new Tuple<string, string>(phoneAndDesc[0].Trim(), phoneAndDesc[1].Trim()));
                });
    
                ApplyForEachItem(data, item => Debug.Print($"Phone: '{item.Item1}', Desc = '{item.Item2}' \r\n"));
            }
    
            public static void ApplyForEachItem<T>(IEnumerable<T> enumerable, Action<T> action)
            {
                if (enumerable == null)
                {
                    return;
                }
    
                foreach (T t in enumerable)
                {
                    action(t);
                }
            }
        }
    }
