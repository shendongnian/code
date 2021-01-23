    [HandleError]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var model = new SystemRoleList
            {
                List = new[]
                {
                    new SystemRole { Id = 1, Name = "role 1" },
                    new SystemRole { Id = 2, Name = "role 2" },
                    new SystemRole { Id = 3, Name = "role 3" },
                }
            };
            return View(model);
        }
        [HttpPost]
        public ActionResult Index(SystemRoleList model)
        {
            return Content("thanks for submitting");
        }
    }
