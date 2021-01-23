    public class CartCollection : IList<Cart>
    {
        public static readonly CartCollection Instance = new CartCollection();
        private CartCollection() { }
        // Implement IList<T> here
    }
