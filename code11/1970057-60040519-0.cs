        namespace Solution.Areas.ControlPanel.Controllers
    {
        [Area(nameof(Foo))]
        [Route(nameof(Foo) + "/[controller]")]
        public class HomeController : Controller
        {
            public IActionResult Index() => View();
        }
    }
