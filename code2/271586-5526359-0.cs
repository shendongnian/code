    public class MyController : Controller
    {
        public string Title { get; set; }
     
        public ActionResult Index()
        {
            this.Title = "My Title";
            return View();
        }
    }
