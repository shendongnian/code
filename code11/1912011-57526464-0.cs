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
                List<Product> products = doc.Descendants("Product").Select(x => new Product() {
                    name = (string)x.Attribute("name"),
                    brand = (string)x.Attribute("brand"),
                    ProductValues = x.Descendants("ProductValue")
                        .GroupBy(y => (string)y.Attribute("name"), z => (string)z.Attribute("value"))
                        .ToDictionary(y => y.Key, z => z.FirstOrDefault())
                }).ToList();
     
            }
        }
        public class Product
        {
            public string name { get; set; }
            public string brand { get; set; }
            public Dictionary<string, string> ProductValues { get; set; }
        }
      
    }
