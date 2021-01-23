    public class MyController: Controller
    {
        private readonly IMyRepository _repository;
        public MyController(IMyRepository repository)
        {
            _repository = repository;
        }
    
        public ActionResult Index(int id)
        {
            var model = _repository.Get(id);
            return View(model);
        }
    }
