    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    using System.Xml;
    using System.Xml.Linq;
    using System.IO;
    namespace ConsoleApplication116
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                string xml = File.ReadAllText(FILENAME);
                XDocument doc = XDocument.Parse(xml);
                XElement root = doc.Root;
                XNamespace ns = root.Descendants().Where(x => x.Name.LocalName == "ZdListGetHeaderResult").FirstOrDefault().GetDefaultNamespace();
                List<HeaderResult> results = root.Descendants(ns + "ZdListGetHeaderResult").Select(x => new HeaderResult()
                {
                    DocId = (int)x.Element(ns + "DocId"),
                    DocNo = (string)x.Element(ns + "DocNo"),
                    DateDoc = (DateTime)x.Element(ns + "DateDoc"),
                    DocStatus = (string)x.Element(ns + "DocStatus"),
                    DocAddressDelivery = (string)x.Element(ns + "DocAddressDelivery"),
                    DocWarehouse = (string)x.Element(ns + "DocWarehouse"),
                    DateRealizationPlanned = (DateTime)x.Element(ns + "DateRealizationPlanned"),
                    lines = x.Descendants(ns + "ZdListGetLinesResult").Select(y => new LinesResult() {
                        PositionItem = (int)y.Element(ns + "PositionItem"),
                        MaterialCode = (int)y.Element(ns + "MaterialCode"),
                        MaterialCatalogNumber = (string)y.Element(ns + "MaterialCatalogNumber"),
                        MaterialDescription = (string)y.Element(ns + "MaterialDescription"),
                        Quantity = (decimal)y.Element(ns + "Quantity"),
                        Unit = (string)y.Element(ns + "Unit"),
                    }).ToList()
                }).ToList();
     
            }
     
     
        }
        public class HeaderResult
        {
            public int DocId   { get; set;}
            public string DocNo   { get; set;}
            public DateTime DateDoc   { get; set;}
            public string DocStatus   { get; set;}
            public string DocAddressDelivery   { get; set;}
            public string DocWarehouse   { get; set;}
            public DateTime DateRealizationPlanned   { get; set;}
            public List<LinesResult> lines { get; set; }
        }
        public class LinesResult
        {
            public int PositionItem { get; set;}
            public int MaterialCode { get; set;}
            public string MaterialCatalogNumber { get; set;}
            public string MaterialDescription { get; set;}
            public decimal Quantity { get; set;}
            public string Unit { get; set; }
        }
     
     
    }
