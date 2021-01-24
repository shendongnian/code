    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.Text.RegularExpressions;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                XElement endpoint = doc.Descendants("endpoint").FirstOrDefault();
                string newIp = "122.13.0.251";
                string address = (string)endpoint.Attribute("address");
                string pattern = "//[^:]+";
                address = Regex.Replace(address, pattern, "//" + newIp);
                endpoint.Attribute("address").SetValue(address);
                doc.Save(FILENAME);
            }
        }
    }
