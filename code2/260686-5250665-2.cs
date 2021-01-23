    public class SomeController
    {
        private readonly IRepository<Customer> repo;
        
        public SomeController(IRepository<Customer> repo)
        {
            this.repo = repo;
        }
    
        public ViewResult Index()
        {
            return View(this.repo.GetAll());
        }
    }
