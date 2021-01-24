    public class BaseController : Controller
    {
         public void callSP(string theParameter){
            db.uspCallTables(theParameter);
         }
    }
