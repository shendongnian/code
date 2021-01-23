    public class AccountController : Controller
    {
        private readonly IUserRepo _userRepo;
        private AccountController(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }
        public ActionResult Login()
        {
            return View();
        }
    }
