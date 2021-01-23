    public class ProductProxy : Product
    {
        private IProductRepository _productRepo;
        public ProductProxy(IProductRepository productRepo)
        {
            _productRepo = productRepo;
        }
        // now you use _productRepo to lazily load something on request, do you?
    }
