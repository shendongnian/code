    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.IO;
    namespace ConsoleApplication106
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                string xml = File.ReadAllText(FILENAME);
                XDocument doc = XDocument.Parse(xml);
                XElement root = doc.Root;
                XNamespace ns = root.GetDefaultNamespace();
                XElement siteDataResult = doc.Descendants(ns + "SiteDataResult").FirstOrDefault();
                XNamespace aNs = siteDataResult.GetNamespaceOfPrefix("a");
                Site site = new Site();
                site.siteName = (string)siteDataResult.Element(aNs + "SiteName");
                site.siteLocation  = (string)siteDataResult.Element(aNs + "SiteLocation");
                site.dict = siteDataResult.Descendants(aNs + "DateIntervalNode")
                    .GroupBy(x => (DateTime)x.Element(aNs + "Date"), y => new KeyValuePair<int, string>(
                        (int)y.Descendants(aNs + "AverageTemperature").FirstOrDefault(),
                        (string)y.Descendants(aNs + "Unit").FirstOrDefault()
                        )
                    )
                    .ToDictionary(x => x.Key, y => y.FirstOrDefault());
            }
        }
        public class Site
        {
            public string siteName { get; set; }
            public string siteLocation { get; set; }
            public Dictionary<DateTime, KeyValuePair<int, string>> dict { get; set; }
        }
    }
