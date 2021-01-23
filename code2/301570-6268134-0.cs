    public class MyController : Controller
    {
        //Executes before every action
        protected override void OnActionExecuting(ActionExecutedContext context) 
        {
            //Call the method from the base class
            base.OnActionExecuting(context);
            
            //Create the ViewBag data here
            ViewBag.XYZ = XYZ();
        }
        //Executes after every action
        protected override void OnActionExecuted(ActionExecutedContext context) 
        {
            //Call the method from the base class
            base.OnActionExecuted(context);
            
            //Create the ViewBag data here
            ViewBag.XYZ = XYZ();
        }
    }
