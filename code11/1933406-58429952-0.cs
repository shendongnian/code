    public class CartItem
    {
        public int NumberItems { get; set; }
        public ProductItem Product { get; set; }
        public CartItem(ProductItem product, int numberItems)
        {
            Product = product;
            NumberItems = numberItems;
        }
    }
