    public class HandleJsonError : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext exceptionContext)
        {
            if (!exceptionContext.HttpContext.Request.IsAjaxRequest() || exceptionContext.Exception == null) return;
            exceptionContext.HttpContext.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
            exceptionContext.Result = new JsonResult
                                       {
                                           Data = new
                                                      {
                                                          exceptionContext.Exception.Message,
                                                          exceptionContext.Exception.StackTrace
                                                      }
                                       };
            exceptionContext.ExceptionHandled = true;
        }
    }
