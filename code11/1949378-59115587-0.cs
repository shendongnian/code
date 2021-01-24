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
                XElement track = doc.Descendants("TRACK").FirstOrDefault();
                XElement newPostitionMark = new XElement("POSITION_MARK", new object[] {
                    new XAttribute("Name", "John"),
                    new XAttribute("Type", 5),
                    new XAttribute("Start", 1.0),
                    new XAttribute("Num", 0)
                });
                track.Add(newPostitionMark);
                doc.Save(FILENAME);
            }
        }
    }
