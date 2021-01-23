    Class ShoppingCart {
    
        public static ShoppingCart Current
        {
          get 
          {
             var cart = HttpContext.Current.Session["Cart"] as ShoppingCart;
             if (null == cart)
             {
                cart = new ShoppingCart();
                HttpContext.Current.Session["Cart"] = cart;
             }
             return cart;
          }
        }
    
    ... // rest of the code
    
    }
