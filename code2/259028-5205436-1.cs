      public class YourController : BaseController
        {
            public JsonResult showcontent()
            {
                // your logic here to return foo json
                return Json ( new { "dfd" }); // just a dummy return text replace it wil your code
            }
        }
    
        public class BaseController : Controller
        {
     // Catch block for all exceptions in your controller
            protected override void OnException(ExceptionContext filterContext)
            {
                base.OnException(filterContext);
                if (filterContext.Exception.Equals(typeof(ApplicationException)))
                {
                    //do  json and return
                }
                else
                {
                    // non applictaion exception
    // redirect to generic error controllor and error action which will return json result
                }
            }
    
        }
