    public class HomeController: Controller
    {
        public ActionResult Index()
        {
            var completed = 5; // get this from somewhere
            var total = 10; // get this from somewhere
            var model = new MyViewModel
            {
                Progress = (1.0 * completed / total)
            }
            return View(model);
        }
    }
