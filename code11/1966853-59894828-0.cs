    public class GenerateUrlAttribute : ActionFilterAttribute
    {
     public override void OnActionExecuting(ActionExecutingContext filterContext)
     {
        GenerateUrl(filterContext); 
     }
   
     private void GenerateUrl(ActionExecutingContext filterContext)
     {
        //your logic 
     }
    }
