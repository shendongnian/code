    public class AlbumAttribute : ActionFilterAttribute
        {
             public override void OnActionExecuting(ActionExecutingContext filterContext)
             {
                 var albumId = filterContext.HttpContext.Request.QueryString["album"] as string;
                 filterContext.ActionParameters["albumId"] = albumId;
    
                 base.OnActionExecuting(filterContext);
             }
        }
