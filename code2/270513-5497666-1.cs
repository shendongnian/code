    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var model = new MyViewModel();
            return View(model);
        }
        public ActionResult Months(int year)
        {
            if (year == 2011)
            {
                return Json(
                    Enumerable.Range(1, 3).Select(x => new { value = x, text = x }), 
                    JsonRequestBehavior.AllowGet
                );
            }
            return Json(
                Enumerable.Range(1, 12).Select(x => new { value = x, text = x }),
                JsonRequestBehavior.AllowGet
            );
        }
    }
