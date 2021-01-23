    public class PersonController : Controller
    {
        static List<Person> people = new List<Person>();
    
        //
        // GET: /Person/
        public ActionResult Index()
        {
            return View(people);
        }
    
        //
        // GET: /Person/Details/5
        public ActionResult Details(Person person)
        {
            return View(person);
        }
    
        //
        // GET: /Person/Create
        public ActionResult Create()
        {
            return View();
        } 
    
        //
        // POST: /Person/Create
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(Person person)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", person);
            }
    
            people.Add(person);
    
            return RedirectToAction("Index");
        }
    }
