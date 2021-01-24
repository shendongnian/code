    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication103
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                Dictionary<string, XElement> dic = doc.Descendants("title")
                    .GroupBy(x => (string)x, y => y)
                    .ToDictionary(x => x.Key, y => y.FirstOrDefault());
     
            }
        }
    }
