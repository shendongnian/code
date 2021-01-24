    public class Controller1 : BaseController
    {
       public ActionResult SPROCButton()
       {
          try
          {
            callSP("MyDB.temp.Table1");
            return RedirectToAction("Index");
          }
          catch (Exception e)
          {
             Console.WriteLine(e);
             throw;
          }
       }
    }
