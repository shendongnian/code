    public class PersonsController : Controller
    {
        private readonly IPersonsRepository _repository;
        public class PersonsController(IPersonsRepository repository)
        {
            _repository = repository;
        }
        public ActionResult Index()
        {
            return View();
        } 
    
        public ActionResult List()
        {
            var persons = _repository.GetPersons();        
            return View(persons);
        }
    }
