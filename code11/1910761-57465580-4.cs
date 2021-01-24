    public class HomeController : Controller
        {
            public async Task<IActionResult> Index()
            {
                var model = new UserViewModel(16,"Bob");
                string name = await model.GetName();
                int age = await model.GetAge();
                return View(model);
            }
        }
