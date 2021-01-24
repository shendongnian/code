    public class ProductsController : ControllerBase
    {
        private readonly ITestRepository<ApplicationDbContext, Product> _repository;
        public TestRepoController(ITestRepository<ApplicationDbContext, Product> repository)
        {
            _repository = repository;
        }
        // GET api/products
        [HttpGet]
        public List<Product> Get()
        {
            return _repository.GetAll();
        }
    }
