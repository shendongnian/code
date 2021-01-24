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
                Dictionary<string, XElement> dict = doc.Descendants("Device")
                    .GroupBy(x => (string)x.Descendants("DeviceName").FirstOrDefault(), y => y)
                    .ToDictionary(x => x.Key, y => y.FirstOrDefault());
            }
        }
    }
