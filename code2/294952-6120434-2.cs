    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View(new DR405Model());
        }
        [HttpPost]
        public ActionResult Index(DR405Model model)
        {
            if (model.File != null && model.File.ContentLength > 0)
            {
                var fileName = Path.GetFileName(model.File.FileName);
                var path = Path.Combine(Server.MapPath("~/App_Data"), fileName);
                model.File.SaveAs(path);
            }
            return RedirectToAction("Index");
        }
    }
