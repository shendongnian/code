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
                List<EndPoint> endPoints = doc.Descendants("endpoint").Select(x => new EndPoint()
                {
                    name = (string)x.Attribute("name"),
                    address = (string)x.Attribute("address"),
                    binding = (string)x.Attribute("binding"),
                    contract = (string)x.Attribute("contract"),
                    bindingConfiguration = (string)x.Attribute("bindingConfiguration"),
                    behaviorConfiguration = (string)x.Attribute("behaviorConfiguration"),
                    dns = (string)x.Descendants("dns").FirstOrDefault().Attribute("value"),
                }).ToList();
            }
        }
        public class EndPoint
        {
            public string name { get; set; }
            public string address { get; set; }
            public string binding { get; set; }
            public string contract { get; set; }
            public string bindingConfiguration { get; set; }
            public string behaviorConfiguration { get; set; }
            public string dns { get; set; }
        }
    }
