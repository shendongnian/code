    public class HomeController: Controller
    {
        public ActionResult Index()
        {
            var model = new MyViewModel
            {
                Categories = new SelectList(Repository.GetCategories(), "Value", "Text")
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult Index(MyViewModel model)
        {
            if (!ModelState.IsValid)
            {
                // there was a validation error =>
                // rebind categories and redisplay view
                model.Categories = new SelectList(Repository.GetCategories(), "Value", "Text");
                return View(model);
            }
            // At this stage the model is OK => do something with the selected category
            return RedirectToAction("Success");
        }
    }
