    class Product {
      public Product Another { get; set; }
      public string Name { get; set; }
    }
    
    var p1 = new Product { Another = null };
    var p2 = new Product { Another = new Product { Name = "Foo" } };
    var p3 = (Product)null;
    
    // prints '' for p1 and p3 (null value) and 'Foo' for p2 (actual value)
    string name = DynamicWrapper.Wrap(p1).Another.Name.Value;
    Console.WriteLine(name);
