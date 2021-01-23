    public class MyController {
      public ActionResult Index() {
        return View();
      }
      
      [ChildActionOnly]
      public ActionResult Menu() {
        var menu = GetMenuFromSomewhere();
          return PartialView(menu);
      }
    }
