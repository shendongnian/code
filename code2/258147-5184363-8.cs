    public class ProductController : Controller
    {
        //
        // GET: /Index/
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Partial1()
        {
           return PartialView();
        }
 
        [Authorize]
        public ActionResult Partial2()
        {
           return PartialView();
        }
    }
