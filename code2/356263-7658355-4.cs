    public class RegistrationController : Controller
    {
        public ActionResult Index()
        {
            RegistrationState model = RegistrationState.Init();
            // just display the "Fill Basic Info" form
            return View(model);
        }
    
        [HttpPost]
        public ActionResult Index(RegistrationState data)
        {
            // process data and redirect to next step
            this.TempData["RegState"] = data;
            if (!this.ModelState.IsValid || data.State == State.Error)
            {
                // error should handle provided state and empty one as well
                return RedirectToAction("Error");
            }
            return RedirectToAction("Package");
        }
    
        public ActionResult Package()
        {
            RegistrationState data = this.TempData["RegState"] as RegistrationState;
            if (data == null)
            {
                return RedirectToAction("Error");
            }
            // get packages and display them
            IList<Package> model = this.repository.GetPackages();
            return View(new Tuple.Create(data, model));
        }
        [HttpPost]
        public ActionResult Package(RegistrationState data)
        {
            // process data blah blah blah
        }
        // and so on and so forth
        ....
    }
