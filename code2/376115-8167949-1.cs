    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View(new SearchViewModel());
        }
        [HttpPost]
        public ActionResult Index(SearchViewModel model)
        {
            if (!ModelState.IsValid)
            {
                // There was a validation error => redisplay the view so 
                // that the user can fix it
                return View(model);
            }
 
            // At this stage we know that the model is valid. The model.Query
            // property will contain whatever value the user entered in the input
            // So here you could search your datastore and return the results
            // You haven't explained under what form you need the results so 
            // depending on that you could add other property to the view model
            // which will store those results and populate it here
            return View(model);
        }
    }
