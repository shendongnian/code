    List<Product> products = new List<Product>();
    products.Add(new Product() { Id =1, Name="Foo"});
    products.Add(new Product() { Id =2, Name="Bar"});
    XElement xDoc = new XElement("Products", products.Select(p => new XElement("Product", 
                                                             new XAttribute("id", p.Id), 
                                                             new XAttribute("name", p.Name))));
    xDoc.Save(@"testOut.xml");
