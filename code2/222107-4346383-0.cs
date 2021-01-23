    public class UserController : BaseController<UserRepository>
    {
        public UserController() : base(new UserRepository(), new UserModelMapper())
        {
            // do stuff
        }
        public ActionResult Index()
        {
            // now you can use syntax like, since "Repository" is type "UserRepository"
            return View(Respository.GetAllUsers());
        }
        public ActionResult Details(int id)
        {
            return View(Respository.GetUser(id));
        }
    }
