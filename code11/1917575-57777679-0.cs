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
                Dictionary<string, string> dict = doc.Descendants("obj").FirstOrDefault().Elements()
                    .GroupBy(x => (string)x.Attribute("name"), y => (string)y.Attribute("val"))
                    .ToDictionary(x => x.Key, y => y.FirstOrDefault());
            }
        }
    }
