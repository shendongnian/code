    [SessionState(System.Web.SessionState.SessionStateBehavior.ReadOnly)]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
      
        
        public ActionResult About()
        {
            Debug.Print(">>> Started working ..." + DateTime.Now);
            Thread.Sleep(10000);
            Debug.Print(">>> Finished!");
            return Content("welcome");
        }
 
    }
