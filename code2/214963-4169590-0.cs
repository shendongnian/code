    public static class CartCollection
    {
        public static readonly List<Cart> Instance = new List<Cart>();
    }
    Cart cart = new Cart();
    cart.SomeProperty = 0;
    CartCollection.Instance.Add(cart);
