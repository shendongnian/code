    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication110
    {
        class Program
        {
            const string INPUT_FILENAME = @"c:\temp\test.xml";
            const string OUTPUT_FILENAME = @"c:\temp\test1.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(INPUT_FILENAME);
                XElement root = doc.Root;
                XNamespace ns = root.GetDefaultNamespace();
                XElement body = root.Element(ns + "body");
                string newBodyStr = "<body><navMap></navMap></body>";
                XElement newBodyX = XElement.Parse(newBodyStr);
                XElement navMap = newBodyX.Element("navMap");
                int count = 1;
                
                foreach (XElement p in body.Descendants(ns + "p"))
                {
                    string innerText = (string)p;
                    XElement newNavPoint = new XElement("navPoint", new object[] {
                        new XAttribute("id", "navPoint-" + count.ToString("d2")),
                        new XAttribute("playOrder", count.ToString("d2")),
                        new XElement("navLabel", new XElement("text", innerText))
                    });
                    navMap.Add(newNavPoint);
                    count++;
                }
                body.ReplaceWith(newBodyX);
                doc.Save(OUTPUT_FILENAME);
            }
        }
    }
