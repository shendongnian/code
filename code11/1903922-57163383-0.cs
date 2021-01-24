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
            public Dictionary<string, string> cases { get; set; }
            public static void ReadXml(XElement xparentSuite, Suite parentSuite)
            {
                foreach (XElement xSuite in xparentSuite.Elements("suite"))
                {
                    if (parentSuite.suites == null) parentSuite.suites = new List<Suite>();
                    Suite newSuite = new Suite();
                    parentSuite.suites.Add(newSuite);
                    parentSuite.cases = xSuite.Descendants("property")
                        .GroupBy(x => (string)x.Attribute("name"), y => (string)y)
                        .ToDictionary(x => x.Key, y => y.FirstOrDefault());
                    ReadXml(xSuite, newSuite);
                }
            }
        }
    }
