    public class TestController : Controller
    {
        public ActionResult Index()
        {
            var viewModel = new TestModel {
                MyInts = new [] { 1, 2, 3, 4 }
                };
            return View(viewModel);
        }
        [HttpPost()]
        public ActionResult Index(TestModel model)
        {
            if (model.MyInts == null) 
            {
                model.MyInts = new int[] { 1, 2, 3, 4 };
            }
            // ...
            
            return RedirectToAction("Index");
        }
    }
