    public class MyController : Controller
    {
    
       public ActionResult Action()
       {
       return View();
       }
    
       [HttpPost]
       public ActionResult Action(MyModel m)
       {
       //
       }
    }
