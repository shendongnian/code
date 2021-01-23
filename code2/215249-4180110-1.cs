    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var model = new MyViewModel
            {
                // TODO: Fill the view model with data from
                // a repository
                Items = Enumerable
                    .Range(1, 5)
                    .Select(i => new Item 
                    { 
                        Value = i, 
                        Text = "item " + i 
                    })
            };
            return View(model);
        }
        [HttpPost]
        public ActionResult Index(MyViewModel model)
        {
            // TODO: based on the value of model.SelectedItemValue 
            // you could perform some action here
            return RedirectToAction("Index");
        }
    }
