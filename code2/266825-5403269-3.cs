    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            Notification = "Hello from index!";
            return View();
        }
    }
    <div>Notification: @(Notification ?? "(null)")</div>
