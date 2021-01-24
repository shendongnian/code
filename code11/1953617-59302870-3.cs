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
                XElement objects = doc.Descendants().Where(x => x.Name.LocalName == "Objects").FirstOrDefault();
                XElement firstObject = objects.Elements().Where(x => x.Name.LocalName == "Object").FirstOrDefault();
                XNamespace ns = firstObject.GetDefaultNamespace();
                List<XElement> sortedObjects = objects.Elements(ns + "Object")
                    .OrderBy(x => (string)x.Descendants(ns + "Revision").FirstOrDefault())
                    .ToList();
                objects.Elements(ns + "Object").Remove();
                objects.Add(sortedObjects);
                doc.Save(FILENAME);
            }
        }
    }
