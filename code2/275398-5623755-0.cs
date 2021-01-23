    using System;
    using System.Linq;
    using System.Xml.Linq;
    using System.Xml.XPath;
    
    public class ProductStream
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string Name { get; set; }
    }
    
    class Program
    {
        static void Main()
        {
            var streams = XDocument
                .Load("test.xml")
                .XPathSelectElements("//ProductData[ProductID='1']/Streams")
                .Select(s => new ProductStream
                {
                    Id = int.Parse(s.Element("id").Value),
                    ProductId = int.Parse(s.Element("productId").Value),
                    Name = s.Element("name").Value
                });
    
            foreach (var stream in streams)
            {
                Console.WriteLine(stream.Name);
            }
        }
    }
