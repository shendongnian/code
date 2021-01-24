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
    
            private static string phoneReg = @"\s+\d[ \d]+";
    
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
    
                ApplyForEachItem(phoneMatches, match => Debug.Print(match.Value.Trim() + "\r\n"));
    
                // OR
    
                ApplyForEachItem(phoneMatches, match => Debug.Print(match.Value.Replace(" ", "") + "\r\n"));
    
                // File.WriteAllText(@"C:\temp\new.html", doc.DocumentNode.InnerHtml.Replace(@"\t", ""));
    
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
