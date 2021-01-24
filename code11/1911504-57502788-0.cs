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
                var results = doc.Descendants("block").Select(x => new
                {
                    name = (string)x.Attribute("name"),
                    count = (int)x.Element("drop").Attribute("count")
                }).ToList();
            }
        }
    }
