    using System;
    using LinqToDB.Mapping;
    
    [Table(Name = "Products")]
    public class Product
    {
      [PrimaryKey, Identity]
      public int ProductID { get; set; }
    
      [Column(Name = "ProductName"), NotNull]
      public string Name { get; set; }
    
      // ... other columns ...
    }
