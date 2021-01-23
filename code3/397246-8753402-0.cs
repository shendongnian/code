    public class CookieStateAttribute : ActionFilterAttribute
        {
            string __key = "querystring";
            
            public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                base.OnActionExecuting(filterContext);
                var viewData = filterContext.Controller.ViewData;
                var request = filterContext.HttpContext.Request;
    
                if (request.Cookies[__key] != null)
                {
                    HttpCookie cookie = request.Cookies[__key];
                    //do something with cookie value
    
                }
                else
                {
                    var cookie = new HttpCookie(__key, "value");
                    request.Cookies.Add(cookie);
                }
            }
        }
