    public class MyController : Controller
    {
        private readonly IMyService _myService;
    
        public MyController(IMyService myService)
        {
            _myService = myService;
        } 
    
        public ActionResults Index()
        {
            var model = _myService.GetModel();
            return View(model);
        }
    }
