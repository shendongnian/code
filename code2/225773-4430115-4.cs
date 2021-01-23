    public class MySpecialController: Controller
    {
        public ActionResult Index()
        {
            // Here you have access to the request, cookies, session, routes, ...
            var someModel = GetSomeModel();
            return View(someModel);
        }
    }
