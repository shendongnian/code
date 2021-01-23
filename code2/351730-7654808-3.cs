    public class ProductController : Controller<Product>
    {
        /// <summary>
        /// Initializes a new instance of the ProductController class.
        /// </summary>
        public ProductController(ILogger<Product> productLogger) : base(productLogger) { }
        public override List<Product> GetItems()
        {
            return new List<Product>();
        }
    }
