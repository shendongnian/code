    public class SecondaryController : Controller
    {
        // GET: Secondary
        public ActionResult Index()
        {
            Debug.Print(">>> Started working ..." + DateTime.Now);
            Thread.Sleep(10000);
            Debug.Print(">>> Finished!");
            return Content("welcome");
        }
    }
