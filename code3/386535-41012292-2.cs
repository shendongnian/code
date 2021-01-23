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
            if (jsonResult == null) return;
            jsonResult.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            base.OnResultExecuting(filterContext);
        }
    }
