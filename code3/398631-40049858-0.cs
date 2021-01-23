    public class LanguageFilterAttribute : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var httpContext = filterContext.RequestContext.HttpContext;
            if (!string.IsNullOrEmpty(httpContext?.Request.QueryString["lang"]))
            {
                if (httpContext.Request.QueryString["lang"].ToLower().StartsWith("en"))
                    httpContext.Session["lang"] = "en";
                else if (httpContext.Request.QueryString["lang"].ToLower().StartsWith("fr"))
                    httpContext.Session["lang"] = "fr";
            }
            if (httpContext.Session["lang"] != null)
            {
                switch (httpContext.Session["lang"].ToString())
                {
                    case "en":
                        Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-GB");
                        break;
                    case "fr":
                        Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("fr-FR");
                        break;
                }
            }
        }
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
        }
    }
