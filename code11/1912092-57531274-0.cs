    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                string response = File.ReadAllText(FILENAME);
                XDocument doc = XDocument.Parse(response);
                List<XElement> getResponseSubscription = doc.Descendants().Where(x => x.Name.LocalName == "getResponseSubscription").ToList();
                XNamespace ns = getResponseSubscription.FirstOrDefault().GetDefaultNamespace();
                var results = getResponseSubscription.Select(x => new
                {
                    id = (string)x.Descendants(ns + "ID").FirstOrDefault(),
                    name = (string)x.Descendants(ns + "name").FirstOrDefault(),
                    address = (string)x.Descendants(ns + "address").FirstOrDefault()
                }).FirstOrDefault();
            }
        }
    }
