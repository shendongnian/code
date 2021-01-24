    public class HomeController : Controller
    {
        private ViewModel viewModel = new ViewModel();
        public IActionResult Index()
        {
            return this.View(viewModel);
        }
