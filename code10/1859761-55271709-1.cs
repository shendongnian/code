    public async Task<IActionResult> GetShoppingCart( [FromQuery] Int32 productId )
    {
        ShoppingCart cart = await this.db.GetShoppingCartAsync( productId );
        
        ShoppingCartViewModel vm = new ShoppingCartViewModel()
        {
            Cart = cart
        };
        return this.View( model: vm );
    }
