    public class HomeController : LongTaskController
    {
        private readonly IRepository _repository;
        public HomeController(IRepository repository)
        {
            _repository = repository;
        }
        public ActionResult Index()
        {
            var c = _repository.GetCompany(34);
            DoLongTask(() =>
            {
                Thread.Sleep(200);
                var c2 = _repository.GetCompany(35);
            });
            return Content(c.Name, "text/plain");
        }
    }
