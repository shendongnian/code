    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            // can load data for edit
            return View(new CreateEntity { Place = new CreateLocation(TempData["Location"] as Location) });
        }
        [HttpPost]
        public ActionResult Index(Entity ent)
        {
            var loc = ent.Place;
            var x = String.Format("{0} {1} {2}", loc.Country, loc.State, loc.City);
            ViewBag.Result = x; // display selected values
            TempData["Location"] = loc;
            return Index();
        }
    }
