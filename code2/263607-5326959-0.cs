    public class AjaxResultActionFilter: ActionFilterAttribute
    {
     
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Request.IsAjaxRequest())
            {
                var result = filterContext.Result as ViewResult;
                result.ViewName = "_" + result.ViewName;
                filterContext.Result = result;
            }
            else
            {
                base.OnResultExecuting(filterContext);
            }
        }
    }
