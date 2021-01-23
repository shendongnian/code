     public class AllowJsonGetAttribute : ActionFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            var jsonResult = filterContext.Result as JsonResult;
            if (jsonResult == null)
                throw new ArgumentException("Action does not return a JsonResult, attribute AllowJsonGet is not allowed");
            jsonResult.JsonRequestBehavior = JsonRequestBehavior.AllowGet;            
            base.OnResultExecuting(filterContext);
        }
    }
