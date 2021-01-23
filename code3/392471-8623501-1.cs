    public class ProductsController : BaseController
    {
        public ProductsController(
            IService<Account> productService) : base(productService)
        {
            _product = productService;
        }
    }
