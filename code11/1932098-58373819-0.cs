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
                XElement node = doc.Root;
                XNamespace sv = node.GetNamespaceOfPrefix("sv");
                Dictionary<string, string> dict = doc.Descendants(sv + "property")
                    .GroupBy(x => (string)x.Attribute(sv + "name"), y => (string)y.Element(sv + "value"))
                    .ToDictionary(x => x.Key, y => y.FirstOrDefault());
            }
        }
    }
