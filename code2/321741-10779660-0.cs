    [MetadataTypeAttribute(typeof(Category.CategoryMetadata))]
    public partial class Category
    {
        internal sealed class CategoryMetadata
        {
            private CategoryMetadata() {
            }
            [Key]
            public int Id { get; set; }
            public string NAME { get; set; }
            [Association("CategoryToProducts", "Id", "CAT")]
            [Include]
            public EntityCollection<Product> Products { get; set; }
        }
    }
    [MetadataTypeAttribute(typeof(Order.OrderMetadata))]
    public partial class Order
    {
        internal sealed class OrderMetadata
        {
            // Metadata classes are not meant to be instantiated.
            private OrderMetadata() {
            }
            [Key]
            public int Id { get; set; }
            public int PRODID { get; set; }
            public DateTime DATE { get; set; }
            public bool DONE { get; set; }
            public int QTY { get; set; }
            [Association("OrderToProduct", "PRODID", "Id", IsForeignKey = true)]
            [Include]
            public Product Product { get; set; }
        }
    }
    [MetadataTypeAttribute(typeof(Product.ProductMetadata))]
    public partial class Product
    {
        internal sealed class ProductMetadata
        {
            private ProductMetadata() {
            }
            [Key]
            public int Id { get; set; }
            public int CAT { get; set; }
            public string NAME { get; set; }
            public string DESC { get; set; }
            public decimal PRICE { get; set; }
            public int QTY { get; set; }
            public long UPC { get; set; }
            [Association("ProdToCat", "CAT", "Id", IsForeignKey = true)]
            [Include]
            public Category Category { get; set; }
            [Association("ProductToOrders", "Id", "PRODID")]
            [Include]
            public EntityCollection<Order> Orders { get; set; }
        }
    }
