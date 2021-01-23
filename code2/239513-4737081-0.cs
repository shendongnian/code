    protected override void OnException(ExceptionContext filterContext)
        {
            if (filterContext.HttpContext.Request.IsAjaxRequest())
            {
                filterContext.Result = Json("...");
            }
            else
            {
                base.OnException(filterContext);
            }
        }
