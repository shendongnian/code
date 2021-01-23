    public class HandleJsonExceptionAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (!filterContext.HttpContext.Request.IsAjaxRequest() || filterContext.Exception == null) return;
            filterContext.HttpContext.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
            filterContext.Result = new JsonResult
                                       {
                                           Data = new
                                                      {
                                                          filterContext.Exception.Message,
                                                          filterContext.Exception.StackTrace
                                                      }
                                       };
            Elmah.ErrorSignal.FromCurrentContext().Raise(filterContext.Exception);
            filterContext.ExceptionHandled = true;
        }
    }
