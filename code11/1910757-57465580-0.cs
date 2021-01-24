    public class HomeController : Controller
        {
            public IActionResult Index()
            {
                var model = new UserViewModel();
                return View(model);
            }
        }
