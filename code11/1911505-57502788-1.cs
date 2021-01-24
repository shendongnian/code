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
                XElement root = doc.Root;
                XNamespace ns = root.GetDefaultNamespace();
                var results = doc.Descendants(ns + "block").Select(x => new
                {
                    name = (string)x.Attribute("name"),
                    count = (int)x.Element(ns + "drop").Attribute("count")
                }).ToList();
            }
        }
    }
