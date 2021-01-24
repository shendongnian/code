    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication132
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                Dictionary<string, string> dict = doc.Descendants("context-param")
                    .GroupBy(x => (string)x.Element("param-name"), y => (string)y.Element("param-value"))
                    .ToDictionary(x => x.Key, y => y.FirstOrDefault());
                string religion = dict["Religion Name"];
            }
        }
    }
