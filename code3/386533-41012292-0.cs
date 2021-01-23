    public sealed class AllowJsonGetAttribute : ActionFilterAttribute, IActionFilter
    {
        void IActionFilter.OnActionExecuted(ActionExecutedContext context)
        {
            var jsonResult = context.Result as JsonResult;
            if (jsonResult == null) return;
            jsonResult.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
        }
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            var jsonResult = filterContext.Result as JsonResult;
            if (jsonResult == null)
            {
                if (filterContext.Result is ViewResult
                    || filterContext.Result is ContentResult
                    || filterContext.Result is RedirectResult) return;
                throw new ArgumentException("Action does not return a JsonResult, attribute AllowJsonGet is not allowed");
            }
            jsonResult.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            base.OnResultExecuting(filterContext);
        }
    }
