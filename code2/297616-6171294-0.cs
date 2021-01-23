    public class LocalizationAwareAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (incoming request doesn't already has the cookie)
            {
                var lc = new HttpCookie("language", 1);
                var cc = new HttpCookie("country", 7);
                filterContext.HttpRequest.Current.Cookies.Add(lc);
                filterContext.HttpRequest.Current.Cookies.Add(cc);
            }
        }
    }
