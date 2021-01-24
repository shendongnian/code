    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication149
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                Dictionary<string, Dictionary<string, List<XElement>>> dict = doc.Descendants("ctCrossTab")
                    .GroupBy(x => (string)x.Attribute("name"), y => y)
                    .ToDictionary(x => x.Key, y => y.GroupBy(a => (string)a.Attribute("value"), b => b)
                        .ToDictionary(a => a.Key, b => b.ToList()));
                        
            }
        }
    }
