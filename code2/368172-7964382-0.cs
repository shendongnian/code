    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AjaxTest()
        {
            return Json(new { HtmlField = "<p>some paragraph</p>" }, JsonRequestBehavior.AllowGet);
        }
    }
