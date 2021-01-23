    public class BaseController : Controller
    {
      public string UrlSessionId { get; set; }
    
      protected override void OnActionExecuting(ActionExecutingContext filterContext)
      {
        base.OnActionExecuting(filterContext);
    
        object sessionId = "";
        if (filterContext.RouteData.Values.TryGetValue("sessionId", out sessionId))
        {
          UrlSessionId = sessionId.ToString();
        }
      }
    }
