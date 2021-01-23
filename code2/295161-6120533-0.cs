    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewData["OtherUncommonOptions"] = new SelectList(
                Enumerable.Range(1, 5).Select(x => new SelectListItem 
                { 
                    Value = x.ToString(), 
                    Text = "item " + x 
                }),
                "Value",
                "Text"
            );
            return View(new Foo());
        }
        [HttpPost]
        public ActionResult Index(Foo model)
        {
            // model.Bar will contain the selected value here
            return View(model);
        }
    }
