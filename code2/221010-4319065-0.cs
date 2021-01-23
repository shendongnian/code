    using System;
    using System.Linq;
    using System.Xml.Linq;
    
    public class Testing
    {
        private void Main()
        {
            var items = new[]
                            {
                                new DataItem
                                    {
                                        Id = 2276138,
                                        Title = "92907-03100-00 WASHER, CHAIN",
                                        Link =
                                            new Uri(
                                            "http://www.mywebsite.com/Product.aspx?ProductId=2453575&SKU=92907-03100-00"),
                                        Price = 0.0M,
                                        Description = "WASHER, CHAIN (92907-03100-00)",
                                        Condition = "New",
                                        Availability = "In Stock",
                                        Manufacturer = "Suzuki"
                                    },
                                new DataItem
                                    {
                                        Id = 2276139,
                                        Title = "92907-03100-01 WASHER, CHAIN",
                                        Link =
                                            new Uri(
                                            "http://www.mywebsite.com/Product.aspx?ProductId=2453575&SKU=92907-03100-00"),
                                        Price = 0.0M,
                                        Description = "WASHER, CHAIN (92907-03100-00)",
                                        Condition = "New",
                                        Availability = "In Stock",
                                        Manufacturer = "Suzuki"
                                    },
                                new DataItem
                                    {
                                        Id = 2276140,
                                        Title = "92907-03100-02 WASHER, CHAIN",
                                        Link =
                                            new Uri(
                                            "http://www.mywebsite.com/Product.aspx?ProductId=2453575&SKU=92907-03100-00"),
                                        Price = 0.0M,
                                        Description = "WASHER, CHAIN (92907-03100-00)",
                                        Condition = "New",
                                        Availability = "In Stock",
                                        Manufacturer = "Suzuki"
                                    },
                            };
            var doc = new XDocument(
                new XElement(
                    "Items",
                    from item in items
                    select
                        new XElement(
                        "Item",
                        new XElement("Id", item.Id),
                        new XElement("Title", item.Title),
                        new XElement("Link", item.Link),
                        new XElement("Price", item.Price),
                        new XElement("Description", item.Description),
                        new XElement("Condition", item.Condition),
                        new XElement("Brand", item.Brand),
                        new XElement("Product_Type", item.ProductType),
                        new XElement("Availability", item.Availability),
                        new XElement("Manufacturer", item.Manufacturer))));
        }
    
        public class DataItem
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public Uri Link { get; set; }
            public decimal Price { get; set; }
            public string Description { get; set; }
            public string Condition { get; set; }
            public string Brand { get; set; }
            public string ProductType { get; set; }
            public string Availability { get; set; }
            public string Manufacturer { get; set; }
        }
    }
