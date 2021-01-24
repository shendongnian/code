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
                var results = doc.Descendants("Info").Select(x => new {
                    desc = (string)x.Element("desc"),
                    email = (string)x.Element("emailAddress"),
                    orgNum = (string)x.Element("orgNum"),
                    type = (string)x.Element("type")
                }).ToList();
            }
        }
    }
