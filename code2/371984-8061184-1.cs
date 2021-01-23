    public class MenuController : Controller
    {
       [ChildActionOnly]
       public ActionResult Menu()
       {
          MenuViewModel model = GenerateMenu();
          return View(model);
       }
    }
