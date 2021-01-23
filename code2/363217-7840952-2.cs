    public class ApplicationContext
    {
        ... as above ...
        public ShoppingBasket ShoppingBasket
        {
            ShoppingBasket shoppingBasket = 
               HttpContext.Current.Session["Basket"] as ShoppingBasket;
            if (shoppingBasket == null)
            {
                shoppingBasket = ... e.g. retrieve from database
                HttpContext.Current.Session["Basket"] = shoppingBasket;
            }
            return shoppingBasket;
        }
    }
