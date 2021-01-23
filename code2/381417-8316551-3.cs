    public class HomeController : Controller
    {
        private IStackoverflowService _stackoverflowService;
    
        public HomeController(IStackoverflowService stackoverflowService)
        {
            _stackoverflowService = stackoverflowService;
        }
    
        public ActionResult Index()
        {
            var model = _stackoverflowService.GetRecentQuestions();
            return View(model);
        }
    }
