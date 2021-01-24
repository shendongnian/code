    public class _baseController
    {
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        base.OnActionExecuting(context);
       System.Attribute[] attrs = System.Attribute.GetCustomAttributes(context.Controller.GetType());
    }    
    }
