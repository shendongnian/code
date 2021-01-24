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
            const string URL = "http://www.ecb.europa.eu/stats/eurofxref/eurofxref-daily.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(URL);
                XNamespace ns = doc.Root.GetDefaultNamespace();
                Dictionary<string, decimal> currenciesDict = doc.Descendants(ns + "Cube")
                    .Where(x => x.Attribute("currency") != null)
                    .GroupBy(x => (string)x.Attribute("currency"), y => (decimal)y.Attribute("rate"))
                    .ToDictionary(x => x.Key, y => y.FirstOrDefault());
            }
        }
    }
