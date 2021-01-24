    public class AuthorizeSheetOwnerAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var characterSheetId = filterContext.RouteData.Values["characterSheetId"].ToString() ;
            //write your logic
            if (false)
            {
                filterContext.Result = new BadRequestObjectResult("Custom error");
            } 
         
        }
    }
