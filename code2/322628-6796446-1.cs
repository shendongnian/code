    public class PeopleController : Controller
    {
        public ActionResult Index()
        {
            var people = Repository.GetPeople();
            return View(people);
        }
     ....
     }
