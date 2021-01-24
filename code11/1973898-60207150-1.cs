    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.IO;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                string xml = File.ReadAllText(FILENAME);
                XDocument doc = XDocument.Parse(xml);
                Dictionary<string, string> dict = doc.Descendants().Where(x => x.Name.LocalName == "return")
                    .FirstOrDefault().Elements().Where(x => (string)x != string.Empty)
                    .GroupBy(x => x.Name.LocalName, y => (string)y)
                    .ToDictionary(x => x.Key, y => y.FirstOrDefault());
     
            }
        }
     
    }
