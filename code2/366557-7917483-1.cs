    private readonly Lazy<List<CartItem>> _cartItems;
 
    public MyClass()
    {
        _cartItems = new Lazy<List<CartItem>>(GetCartItems);
    }
    public List<CartItem> GetCartItems()
    {
        return Services.CartItemService.GetCartItems();
    }
