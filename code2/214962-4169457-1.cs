    public static class CartCollection
    {
        private static List<Cart> _list = new List<Cart>();
    
        public static void Add(Cart Cart)
        {
            _list.Add(Cart);
        }
    }
