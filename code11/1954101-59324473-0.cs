    using System;
    using System.Collections.Generic;
    using System.Collections;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.IO;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                StreamReader reader = new StreamReader(FILENAME);
                reader.ReadLine(); // skip the utf-16 which Net doesn't like
                XDocument doc = XDocument.Load(reader);
                Dictionary<int, XElement> dict = doc.Descendants("DialValue")
                    .GroupBy(x => (int)x.Element("Dial").Attribute("id"), y => y)
                    .ToDictionary(x => x.Key, y => y.FirstOrDefault());
            }
        }
    }
