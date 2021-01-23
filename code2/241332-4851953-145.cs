    public interface IValidationProvider
    {
        void Validate(object entity);
        void ValidateAll(IEnumerable entities);
    }
    public class ProductService : IProductService
    {
        private readonly IValidationProvider validationProvider;
        private readonly IProductRespository repository;
        public ProductService(
            IProductRespository repository,
            IValidationProvider validationProvider)
        {
            this.repository = repository;
            this.validationProvider = validationProvider;
        }
        
        // Does not return an error code anymore. Just throws an exception
        public void CreateProduct(Product productToCreate)
        {
            // Do validation here or perhaps even in the repository...
            this.validationProvider.Validate(productToCreate);
            
            // This call should also throw on failure.
            this.repository.CreateProduct(productToCreate);
        }
    }
