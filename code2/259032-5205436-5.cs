    //not tested code
    public class HandleErrorfilter : HandleErrorAttribute
        {
             public string ErrorMessage { get; set; }
    
            public override void OnException(ExceptionContext filterContext)
            {
                    string message = string.Empty;
                    //if application exception
                    // do  something
                     else
                        message = "An error occured while attemting to perform the last action.  Sorry for the inconvenience.";
                }
                else
                {
                    base.OnException(filterContext);
                }
            }
    
          public class YourController : BaseController
            {
                [HandleErrorfilter]
                public JsonResult showcontent()
                {
                    // your logic here to return foo json
                    return Json ( new { "dfd" }); // just a dummy return text replace it wil your code
                }
            }
