    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication120
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument xml = XDocument.Load(FILENAME);
                XElement root = xml.Root;
                XNamespace ns = root.GetNamespaceOfPrefix("alv");
                var results = xml.Descendants(ns + "ROWS").SelectMany(rows =>
                   rows.Descendants("ROW").Where(r => r.Attribute("type").Value == "D")
                   .Where(f => !f.Elements("CELL").Any(f1 => ((string)f1.Attribute("name") == "C006") && ((string)f1.Element("VALUE") == "LEIS")))
                   .Select(d => new SAPDevice()
                   {
                       MaterialNumber = (string)d.Elements("CELL").Where(cell => (string)cell.Attribute("name") == "C002").Select(val => val.Element("VALUE")).FirstOrDefault(),
                       PartNumber = d.Elements("CELL").Where(cell => (string)cell.Attribute("name") == "C011").Select(val => (string)val.Element("VALUE")).FirstOrDefault(),
                       Quantity = (int?)d.Elements("CELL").Where(cell => (string)cell.Attribute("name") == "C004").Select(val => val.Element("VALUE")).FirstOrDefault(),
                       Price = (decimal?)d.Elements("CELL").Where(cell => (string)cell.Attribute("name") == "C008").Select(val => val.Element("VALUE")).FirstOrDefault(),
                       Description = (string)d.Elements("CELL").Where(cell => (string)cell.Attribute("name") == "C003").Select(val => val.Element("VALUE")).FirstOrDefault(),
                   //     //MaterialType = d.Elements("CELL").Where(cell => cell.Attribute("name").Value == "C006").Select(val => val.Element("VALUE").Value).First()
                   })).ToList();
            }
     
        }
        public class SAPDevice
        {
            public object test { get; set; }
            public string MaterialNumber { get; set; }
            public string PartNumber { get; set; }
            public int? Quantity { get; set; }
            public decimal? Price { get; set; }
            public string Description { get; set; }
        }
    }
