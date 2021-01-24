    public class MyViewModel
    {
      [Display(Name="My Products")]
      public IEnumerable<Product> Products {get; set;}
      public ProductCategory ProductCategory {get; set;} 
    }
