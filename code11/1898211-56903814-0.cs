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
                var results = doc.Descendants("AAA")
                    .GroupBy(x => x.Element("Group"))
                    .Select(x => new
                    {
                        group = x.Key,
                        id = (string)x.Descendants("Id").FirstOrDefault(),
                        host = (string)x.Descendants("Host").FirstOrDefault()
                    })
                    .ToList();
            }
        }
    }
