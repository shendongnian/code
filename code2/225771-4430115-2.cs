    public class MySpecialController: Controller
    {
        public ActionResult Index()
        {
            var someModel = GetSomeModel();
            return View(someModel);
        }
    }
