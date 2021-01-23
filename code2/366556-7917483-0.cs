    private readonly Lazy<List<CartItem>> _cartItems;
 
    public MyClass()
    {
        _cartItems = new Lazy<List<CartItem>>(() => Services.CartItemService.GetCartItems());
    }
