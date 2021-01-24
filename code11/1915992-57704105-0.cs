    Public class WebApiController
    {
      [CustomAttribute]
      public IActionResult ActionMethod1()
      {
         WebApiController222 obj = new WebApiController222()
         return obj.ActionMethod2Internal(); // Calling to second Action Methods
      }
    }
    public class WebApiController222
    {
      [CustomAttribute]
      public IActionResult ActionMethod2()
      {
        return ActionMethod2Internal();
      }
      public IActionResult ActionMethod2Internal()
      {
        //source code
      }
    }
    // CustomAttribute
    public class CustomAttribute : ActionFilterAttribute
    {  
      public override void OnActionExecuting(ActionExecutingContext context()
      {
        //Some Code
      }
    }
