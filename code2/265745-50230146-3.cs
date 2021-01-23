    public class ProductId : TypedGuid
    {
        public static ProductId Empty => new ProductId(Guid.Empty);
        public static ProductId New => new ProductId(Guid.NewGuid());
        public ProductId(Guid value) : base(value)
        {
        }
    }
