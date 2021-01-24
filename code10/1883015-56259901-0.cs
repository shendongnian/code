    public class MyCustomActionFilterAttribute : ActionFilterAttribute
    {
      public override void OnActionExecuting(ActionExecutingContext context)
      {
        // Check some condition 
        if (true == false)
        {
          // Return a bad request response without executing the action method
          context.Result = new BadRequestResult();
        }
      }
    }
