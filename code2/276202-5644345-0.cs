    public static ShoppingCart GetCurrent
    {
        get
        {
            if(HTTPContext.Current.Session["CurrentCart"] == null)
            {
                HTTPContext.Current.Session["CurrentCart"] = new ShoppingCart();
            }
            return HTTPContext.Current.Session["CurrentCart"] as ShoppingCart;
        }
    }
