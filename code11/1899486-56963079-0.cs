    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                Dictionary<string, List<string>> dict = doc.Descendants("Job")
                    .GroupBy(x => (string)x.Attribute("Name"), y => y)
                    .ToDictionary(x => x.Key, y => y.Elements("Path").Select(z => (string)z).ToList());
            }
        }
    }
