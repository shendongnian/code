    public class HomeController : Controller
    {
    
        public ActionResult Index()
        {
            // won't work
            return MyCustomResult();
        }
    
        public ActionResult List()
        {
            // will work
            return this.MyCustomResult();
        }
    }
    
    public static class MyExtensions
    {
        public static MyResult MyCustomResult(this Controller instance)
        {
             return new SomeResult(instance.ActionName);
        }
    }
