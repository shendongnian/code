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
                XNamespace ns = doc.Root.GetDefaultNamespace();
                var results = doc.Descendants(ns + "Info").Select(x => new
                {
                    desc = (string)x.Element(ns + "desc"),
                    email = (string)x.Element(ns + "emailAddress"),
                    orgNum = (string)x.Element(ns + "orgNum"),
                    type = (string)x.Element(ns + "type")
                }).ToList();
            }
        }
    }
