    public class RegistrationController : Controller
    {
        public ActionResult Index()
        {
            // just display the "Fill Basic Info" form
            return View();
        }
    
        [HttpPost]
        public ActionResult Index(BasicInfo info)
        {
            // process data and redirect to next step
            if (!this.ModelState.IsValid)
            {
                return RedirectToAction("Error");
            }
            return RedirectToAction("Package");
        }
    
        public ActionResult Package()
        {
            // get packages and display them
            IList<Package> model = this.repository.GetPackages();
            return View(model);
        }
        public ActionResult Package(Package selectedPackage)
        {
            // process data blah blah blah
        }
        // and so on and so forth
        ....
    }
