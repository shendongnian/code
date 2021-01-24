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
                XElement objects = doc.Descendants(ns + "Objects").FirstOrDefault();
                List<XElement> sortedObjects = objects.Elements(ns + "Object")
                    .OrderBy(x => (string)x.Descendants(ns + "Revision").FirstOrDefault())
                    .ToList();
                objects.ReplaceWith(new XElement("Objects", sortedObjects));
                doc.Save(FILENAME);
            }
        }
    }
