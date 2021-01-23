    public class HomeController : Controller
    {
        private StackoverflowService _stackoverflowService;
    
        public HomeController(StackoverflowService stackoverflowService)
        {
            _stackoverflowService = stackoverflowService;
        }
    
        public ActionResult Index()
        {
            var model = _stackoverflowService.GetRecentQuestions();
            return View(model);
        }
    }
