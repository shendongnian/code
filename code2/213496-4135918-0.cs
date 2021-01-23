            XDocument xml = XDocument.Parse(@"<?xml version=""1.0"" encoding=""UTF-8""?>
                                                <MyProducts>
                                                    <Product Name=""P1"" /> 
                                                    <Product Name=""P2"" /> 
                                                </MyProducts>");
            foreach(var product in xml.Descendants(XName.Get("Product")))
            {
                var p = new Product { Name = product.Attribute(XName.Get("Name")).Value };
               // Manipulate your result and add to your collection.
            }
            ...
            public class Product
            {
               public string Name { get; set; }
            }
