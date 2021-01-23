    public class Cart
    {
      ...
      public List<CartItem> Lines {get; set; }
    }
    
    public class CartItem
    {
      public Product Product {get; set;}
      public int Quantity {get; set;}
      ...
    }
