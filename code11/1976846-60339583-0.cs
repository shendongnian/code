    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication157
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                Dictionary<string, List<List<string>>> dict = doc.Descendants().Where(x => x.Name.LocalName.ToUpper().StartsWith("SETTINGS"))
                    .GroupBy(x => x.Name.LocalName.ToUpper(), y => y.Elements().Select(a => new List<string> { a.Name.LocalName, (string)a }).ToList())
                    .ToDictionary(x => x.Key, y => y.FirstOrDefault());
            }
        }
    }
