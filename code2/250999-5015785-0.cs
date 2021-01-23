    List<ShopCheckOut.CartItem> cart = new List<ShopCheckOut.CartItem>();
            if (HttpContext.Current.Session["ShoppingCart" + HttpContext.Current.Session.SessionID] != null)
            {
                cart = (List<ShopCheckOut.CartItem>)HttpContext.Current.Session["ShoppingCart" + HttpContext.Current.Session.SessionID];
        }
