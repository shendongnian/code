    public class HomeController: Controller
    {
        public ActionResult Index()
        {
            var model = new MyViewModel
            {
                Description = "<p>Hello</p>"
            };
            return View(model);
        }
        
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult UpdateProductVariant(MyViewModel model)
        {
            ...
        }
    }
