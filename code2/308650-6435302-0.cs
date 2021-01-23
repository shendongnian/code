    class ProductList : List<Product>
    {
       public ProductList(items IEnumerable<Product>) 
             : base (items)
       {
       }
    }
    
    class Product
    {
      public string ID { get; set;}
      public string Name{ get; set;}
    }
    
    var products = xDocument.Desendants("product");
    var productList = new ProductList(products.Select(s => new Product()
        {
          ID = s.Element("id").Value,
          Name= s.Element("name").Value
        });
