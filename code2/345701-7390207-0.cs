    public class ProductsController: Controller
    {
        private readonly IProductsRepository _repository;
        public ProductsController(IProductsRepository repository)
        {
            _repository = repository;
        }
        public ActionResult Index(int id)
        {
            var product = _repository.Get(id);
            return View(product);
        }
    }
