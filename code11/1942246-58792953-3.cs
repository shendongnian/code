    public class CommandeController : Controller
    {
      public ActionResult Index()
      {
        return View("Index", MyModel);
      }
    
      public PartialViewResult FirstViewAction(MyModel model)
      {
        ............
        return PartialView("FirstView", FirstModel);
      }
    
      public PartialViewResult SecondViewAction()
      {
         ...........
         return PartialView("SecondView", SecondModel);
      }
    }
