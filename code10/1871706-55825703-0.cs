    public class CustomActionFilters : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            string longurl = HttpContext.Current.Request.Url.AbsoluteUri;
            var uriBuilder = new UriBuilder(longurl);
            var query = HttpUtility.ParseQueryString(uriBuilder.Query);
            var myAllcustomparamter = "myAllcustomparamterhere";
            query.Add("customPara", myAllcustomparamter);
            uriBuilder.Query = query.ToString();
            longurl = uriBuilder.ToString();
            if (!filterContext.HttpContext.Request.QueryString.HasValue || (filterContext.HttpContext.Request.QueryString.HasValue && !filterContext.HttpContext.Request.QueryString.Value.Contains("customPara")))
            {
                filterContext.Result = new RedirectResult(longurl);
            }                       
        }
    }
