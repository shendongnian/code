    class Category {
      public Int32 Id { get; set; }
      public String Name { get; set; }
      public IEnumerable<Product> Products { get; set; }
    }
    
    public class Product {
      public String Name { get; set; }
    }
