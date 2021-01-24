    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication120
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                XElement group = doc.Root;
                Suite rootSuite = new Suite();
                Suite.ReadXml(group, rootSuite);
            }
     
        }
        public class Suite
        {
            public List<Suite> suites { get; set; }
            public List<Case> cases { get; set; }
            public Dictionary<string, string> properties { get; set; }
            public string type { get; set; }
            public static void ReadXml(XElement xparentSuite, Suite parentSuite)
            {
                foreach (XElement xSuite in xparentSuite.Elements("suite"))
                {
                    parentSuite.type = (string)xSuite.Attribute("type");
                    if (parentSuite.suites == null) parentSuite.suites = new List<Suite>();
                    Suite newSuite = new Suite();
                    parentSuite.suites.Add(newSuite);
                    XElement properties = xSuite.Element("properties");
                    if (properties != null)
                    {
                        parentSuite.properties = properties.Elements("property")
                            .GroupBy(x => (string)x.Attribute("name"), y => (string)y)
                            .ToDictionary(x => x.Key, y => y.FirstOrDefault());
                    }
                    parentSuite.cases = xSuite.Elements("case").Select(x => new Case(x)).ToList();
                    ReadXml(xSuite, newSuite);
                }
            }
        }
        public class Case
        {
            public string id { get; set; }
            public string name { get; set; }
            public Dictionary<string, string> properties { get; set; }
            public Case() { }
            public Case(XElement _case)
            {
                id = (string)_case.Attribute("id");
                name = (string)_case.Attribute("name");
                properties = _case.Descendants("property")
                    .GroupBy(x => (string)x.Attribute("name"), y => (string)y)
                    .ToDictionary(x => x.Key, y => y.FirstOrDefault());
            }
        }
    }
