    public class MyActionFilterAttribute : ActionFilterAttribute
    {
         public override void OnResultExecuting(ResultExecutingContext context)
         {
             var action = context.RouteData.Values["action"];
             //do something with action here
             base.OnResultExecuting(context);
         }
     }
