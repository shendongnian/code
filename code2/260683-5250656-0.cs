    public class MyController : Controller
    {
        public IRepository<Customer> CustomerRepo { get; protected set; }
        public MyController(IRepository<Customer> customerRepo)
        {
            CustomerRepo = customerRepo;
        }
        public ViewResult Index()
        {
            return View(CustomerRepo.GetAll());
        }
    }
