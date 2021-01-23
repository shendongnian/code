    public class MyClass {
      public virtual int Id { get; set; }
      protected virtual decimal Price1 { get; set; }  
      protected virtual decimal Price2 { get; set; }  
      protected virtual decimal Price3 { get; set; }  
    //...
      public decimal[] Prices 
      { get 
        {
          return new decimal[] {Price1, Price2, Price3};
        }
      }
    }
