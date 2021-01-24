    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.IO;
    namespace ConsoleApplication110
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                string xml = File.ReadAllText(FILENAME);
                XDocument doc = XDocument.Parse(xml);
                XElement root = doc.Root;
                XNamespace ns = root.GetDefaultNamespace();
                Dictionary<int, List<string>> results = doc.Descendants(ns + "Record")
                    .GroupBy(x => (int)x.Attribute("row"), y => y)
                    .ToDictionary(x => x.Key, y => y.Descendants(ns + "Field").Select(z => (string)z.Attribute("element")).ToList());
            }
        }
    }
