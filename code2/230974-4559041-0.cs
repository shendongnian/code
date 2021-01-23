    public class AlbumAttribute : ActionFilterAttribute
        {
             public override void OnActionExecuting(ActionExecutingContext filterContext)
             {
                 var albumId = Request.QueryString["album"] as string;
                 filterContext.ActionParameters["albumId"] = albumId;
    
                 base.OnActionExecuting(filterContext);
             }
        }
