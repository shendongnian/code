    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication157
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                var results = doc.Descendants("Etiquette")
                    .SelectMany(x => x.Descendants("string")
                        .Select(y => new { BgColor = (string)x.Element("BgColor"), BorderColor = (string)x.Element("BorderColor"), UID = (string)y }))
                    .ToList();
            }
        }
    }
