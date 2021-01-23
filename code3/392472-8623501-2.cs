    public class ProductsController : BaseController
    {
        public ProductsController(
            IService<Account> productService) : base(new SequenceService())
        {
            _product = productService;
        }
    }
