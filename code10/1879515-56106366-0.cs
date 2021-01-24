    [ChildActionOnly]
    public ActionResult cartDropDown()
    {
        return PartialView("_cartDetails", preparecartDropDown(this.HttpContext));
    }
    [ChildActionOnly]
    public ActionResult RemoveFromCart(...)
    {
    	//Delete data
        return PartialView("_cartDetails", preparecartDropDown(this.HttpContext));
    }
    private ShoppingCartViewModel preparecartDropDown(HttpContext context)
    {
        var cart = ShoppingCart.GetCart(context);
        var viewModel = new ShoppingCartViewModel
        {
            CartItems = cart.GetCartItems(),
            CartTotal = cart.GetTotal(),
            ItemCount = cart.GetCount(),
            Message = Server.HtmlEncode("There are no items in your cart. Continue shopping.")
        };
        foreach (var item in viewModel.CartItems)
        {
            item.item = db.Items.Single(i => i.ItemID == item.ItemID);
        }
    
        return viewModel;
    }
