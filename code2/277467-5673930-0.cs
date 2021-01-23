        public class Delivery
        {
            public List<Product> Products { get; set; }
            public Delivery()
            {
                Products = new List<Product>();
            }
        }
        public class Product
        {
            public List<ProductDetail> ProductDetails { get; set; }
            public Product()
            {
                ProductDetails = new List<ProductDetail>();
            }
        }
        public class ProductDetail
        {
            public string Summary { get; set; }
            public string Details { get; set; }
        }
