    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View(new MyViewModel());
        }
        [HttpPost]
        public ActionResult Index(MyViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var fileName = Path.GetFileName(model.File.FileName);
            var path = Path.Combine(Server.MapPath("~/App_Data"), fileName);
            model.File.SaveAs(path);
            return RedirectToAction("Index");
        }
    }
