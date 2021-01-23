    public class MyCookieSettingFilterAttribute : ActionFilterAttribute 
    {
    public override void OnActionExecuted(ActionExecutedContext filterContext)
    {
    filterContext.HttpContext.Response.Cookies.Add(new HttpCookie(name, value));
    }
    }
