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
                List<Fruit_Group> groups = doc.Descendants("Fruit_group").Select(x => new Fruit_Group()
                {
                    groupName = (string)x.Attribute("name"),
                    typeName = (string)x.Element("fruit_types").Attribute("name"),
                    fruits = x.Elements("fruit_types").Elements("fruit").Select(y => (string)y).ToArray(),
                    excluded = x.Descendants("excluded_fruits").Elements("fruit").Select(y => (string)y).ToArray()
                }).ToList();
            }
        }
        public class Fruit_Group
        {
            public string groupName { get; set;}
            public string typeName { get; set; }
            public string[] fruits { get; set; }
            public string[] excluded { get; set; }
        }
    }
