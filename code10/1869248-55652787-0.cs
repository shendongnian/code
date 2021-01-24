    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication108
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                Dictionary<string, string> dict = doc.Descendants("attr")
                    .GroupBy(x => (string)x.Attribute("name"), y => (string)y)
                    .ToDictionary(x => x.Key, y => y.FirstOrDefault());
            }
        }
     
    }
