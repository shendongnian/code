    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication117
    {
        class Program
        {
            const string INPUT_FILE = @"c:\temp\test.xml";
            const string OUTPUT_FILE = @"c:\temp\test1.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(INPUT_FILE);
                XElement b = doc.Descendants("b").FirstOrDefault();
                List<XElement> items = b.Descendants("item").Select(x =>
                    new XElement("b", new object[] {
                            new XAttribute("type", "object"),
                            x.Nodes()
                        })
                    ).ToList();
                b.ReplaceWith(items);
                doc.Save(OUTPUT_FILE);
            }
        }
    }
