    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.Text.RegularExpressions;
    namespace ConsoleApplication146
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                
                XDocument doc = XDocument.Load(FILENAME);
                 Dictionary<string, List<object>> dict = doc.Descendants("product")
                    .Select(x => new { id = (string)x.Element("id"), category = GetCDATA(x.Element("category").FirstNode), name = (string)GetCDATA(x.Element("name").FirstNode) })
                    .SelectMany(x => x.category.Split(new char[] {','}).Select(y => new { id =int.Parse(y), category = y, name = x.name}))
                    .GroupBy(x => x.category, y => (object)y)
                    .ToDictionary(x => x.Key, y => y.ToList());
            }
            static string GetCDATA(object input)
            {
                string pattern = @"CDATA\[(?'data'[^\]]+)";
                return Regex.Match(input.ToString(), pattern).Groups["data"].Value;
            }
        }
    }
