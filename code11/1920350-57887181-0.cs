    using System;
    using System.Collections.Generic;
    using System.Collections;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication131
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                List<string> l1 = new List<string>();
                
                XDocument doc1 = XDocument.Load(FILENAME);
                XElement root = doc1.Root;
                XNamespace xsiNs = root.GetNamespaceOfPrefix("xsi");
                Dictionary<string, List<XElement>> dict = doc1.Descendants("Settings")
                    .GroupBy(x => (string)x.Attribute(xsiNs + "type"), y => y)
                    .ToDictionary(x => x.Key, y => y.ToList());
                dict["FileModel"].Remove();
            }
        }
     
    }
