    public class UserController : Controller
    {
        private readonly IUserRepository _repo;
        public UserController(IUserRepository repo)
        {
            _repo = repo;
        }
    
        public ActionResult Index()
        {
            return RedirectToAction("List");
        }
    
        public ActionResult List()
        {
            IQueryable<Business.Entities.User> users = _repo.GetAll();
            return View("List", users);
        }
    }
