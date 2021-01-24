    public class Product
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public string Country { get; set; }
        public string Brand { get; set; }
        public Product(XElement element)
        {
            ID = element.Element("id").Value;
            Name = element.Element("name").Value;
            List<XElement> properties = element.Elements("property").ToList();
            Color = properties.Where(x => x.Attribute("name").Value == "color").First().Value;
            Country = properties.Where(x => x.Attribute("name").Value == "country").First().Value;
            Brand = properties.Where(x => x.Attribute("name").Value == "brand").First().Value;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            XDocument doc = XDocument.Load("xml.xml");
            XElement productElement = doc.Descendants("product").First();
            Product product = new Product(productElement);
        }
    }
