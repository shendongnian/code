    public class StartController : Controller
    {
      public ActionResult Index()
      {
        return RedirectToAction("Index", "MyController", new { area = "MyArea" });
      }
    }
