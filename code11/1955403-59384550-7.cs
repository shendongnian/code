    public class MyExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            Exception ex = context.Exception;
    		Logger.Error(ex);
        }
    }
    
    [Route("api/[controller]")]
    [MyExceptionFilter]
    public class HomeController : Controller
    {
    	// Action methods
    }
