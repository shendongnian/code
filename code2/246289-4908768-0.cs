    public class AddCommonData : ActionFilterAttribute 
    {
      public override void OnResultExecuting(ResultExecutingContext filterContext)
      {
        ViewResult viewResult = filterContext.Result as ViewResult;
        if (viewResult != null)
        {
          //...
        } 
      }
    }
