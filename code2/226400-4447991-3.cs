    public class ProductsService
    {
        private readonly IProductsRepository _repository;
        public ProductsService(IProductsRepository repository)
        {
            _repository = repository;
        }
        public void SomeBusinessOperation(int productId)
        {
            var product = _repository.Get(productId);
            // TODO: update some properties of the product
            _repository.Save(product);
        }
    }
