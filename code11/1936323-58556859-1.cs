public override void OnActionExecuting(ActionExecutingContext context)
{
  var allowAnonAttr = Attribute.GetCustomAttribute(context.Controller.GetType(), typeof(AllowAnonymousAttribute));
  if(allowAnonAttr != null)
  {
    // do something
  }
}
In older versions of ASP.NET, you also have to reference `System.Reflection` to make use of the `GetCustomAttribute` extension.
Note that this solution works for attributes placed on the controller class itself (as asked in the question), but will not work for attributes placed on action methods. To get it to work for action methods, the below works:
public override void OnActionExecuting(ActionExecutingContext context)
{
  var descriptor = context.ActionDescriptor as ControllerActionDescriptor;
  var actionName = descriptor.ActionName;
  var actionType = context.Controller.GetType().GetMethod(actionName);
  var allowAnonAttr = Attribute.GetCustomAttribute(actionType, typeof(AllowAnonymousAttribute));
  if(allowAnonAttr != null)
  {
    // do something
  }
}
