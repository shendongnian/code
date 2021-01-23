    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View(new MyModel
            {
                SomeInt = new Changeable<int>
                {
                    Changed = true,
                    Value = 5
                }
            });
        }
        [HttpPost]
        public ActionResult Index(MyModel model)
        {
            return View(model);
        }
    }
