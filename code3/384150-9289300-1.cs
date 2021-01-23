     public class HomeController
     {
        private readonly IExampleService _service;
        public HomeController()
        {
          _service = Container.Instance.Resolve<IExampleService>();
        }
        public ActionResult Index()
        {
          return View(_service.GetSomething());
        }
     }
