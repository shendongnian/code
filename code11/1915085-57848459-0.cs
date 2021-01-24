`
    
     public decimal? ShopDeal()
        {
            decimal? shopdeal = 0;
            var results = (from cartItems in db.Carts
                           where cartItems.CartId == ShoppingCartId
                           select new { cartItems.StoreId,cartItems.OrderLimit,cartItems.Duration,cartItems.ShopDiscount }).Distinct().ToList();
                //db.Carts.Select(m => new { m.StoreId, m.OrderLimit, m.ShopDiscount, m.Giftback, m.Duration }.where()).Distinct().ToList();
           
                
            foreach (var item in results)
            {
                decimal? shoptotal = (from cartItems in db.Carts
                                      where cartItems.CartId == ShoppingCartId
                                      && cartItems.Item.StoreId == item.StoreId
                                      select (decimal?)cartItems.Item.Price).Sum();
                if (shoptotal >= item.OrderLimit && item.Duration == "Started")
                {
                    shopdeal = shopdeal + shoptotal * item.ShopDiscount / 100;
                }
            }
            return shopdeal;
        }
regards 
fiaz ahmed ranjha
