    public partial class Product
    {
        public int ProductId { get; set; }           // <- mapped to DB
        public DateTime? ShippingDate { get; set; }  // <- mapped to DB
        public int ShippedQuantity { get; set; }     // <- mapped to DB
        // Static expression which must be understood
        // by LINQ to Entities, i.e. translatable into SQL
        public static Expression<Func<Product, bool>> IsShippedExpression
        {
            get { return p => p.ShippingDate.HasValue && p.ShippedQuantity > 0; }
        }
        public bool IsShipped // <- not mapped to DB because readonly
        {
            // Compile expression into delegate Func<Product, bool>
            // and execute delegate
            get { return Product.IsShippedExpression.Compile()(this); }
        }
    }
