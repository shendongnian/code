    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.Text.RegularExpressions;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                var results = doc.Descendants()
                    .Where(x => (x.NodeType == XmlNodeType.Element) && (x.Elements().Count() == 0))
                    .Select(x => GetAttributes((string)x))
                    .Where(x => x != null)
                    .Select(x => new { name = x.Groups["name"].Value, rule = x.Groups["rule"].Value })
                    .ToList();
            }
            static Match GetAttributes(string innertext)
            {
                Match match = null;
                string pattern = "name=\"(?'name'[^\"]+)\"\\s+ruleAttrib=\"(?'rule'[^\"]*)";
                match = Regex.Match(innertext, pattern);
                if (!match.Success) match = null;
                
                return match;
            }
        }
    }
