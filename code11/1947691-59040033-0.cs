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
            const string URL = "http://www.fuelprices.gr/test/xml/get_prices.view";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(URL);
                List<Code> codes = doc.Descendants("priceentry").Select(x => new Code()
                {
                    id = (string)x.Element("product").Element("code"),
                    price = decimal.Parse(((string)x.Element("price")).Replace(",","")),
                    name = (string)x.Element("name"),
                    description = (string)x.Element("product").Element("description"),
                    lastUpdate = (string)x.Element("timestamp")
                }).ToList();
                Dictionary<int, List<Code>> dict = codes.GroupBy(x => x.id, y => y)
                    .ToDictionary(x => x.Key, y => y.ToList());
            }
        }
        public class Code
        {
            public String id { get; set; }
            public decimal price { get; set; }
            public String name { get; set; }
            public String description { get; set; }
            public String lastUpdate { get; set; }
        }
    }
