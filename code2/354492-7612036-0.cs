    public class Order
    {
      private IProduct _product;
      public Order(IProduct product)
      {
        _product = product;
      }
    
      public int Count {get;set;}
    }
