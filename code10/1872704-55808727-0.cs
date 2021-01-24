    public class ProductCategoryRepository : Repository<ProductCategory>, IProductCategoryRepository
    {
        private ProductSubcategoryRepository subRepo;
        public ProductCategoryRepository(DbContext context) : base(context)
        {
            subRepo = new ProductSubcategoryRepository(context);
        }
        public IEnumerable<ProductCategory> GetProductCategoriesBeforeDate()
        {
            // call subRepo
        }
    }
