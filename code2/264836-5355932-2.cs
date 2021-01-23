       public class RedirectFilter : ActionFilterAttribute {
    
        public override void OnActionExecuting(ActionExecutingContext filterContext){
            if (filterContext.HttpContext.Request.Url.Contains("xyz.com")){
                var url = filterContext.HttpContext.Request.Url.ToString().Replace("xyz.com", "www.xyz.com"));
                filterContext.Result = new RedirectResult(url);
            }
        }
      }
