    public class Product 
    {     
      public string Name { get; set; }     
      public string Description { get; set; }     
      public ProductColors Colors { get; set; } 
    } 
    
    public class PendingProduct : Product 
    {         
      public int ColorCount { get; set; } 
    }
