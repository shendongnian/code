public class CustomControllerResolver : IControllerActivator
{
    public object Create(ControllerContext actionContext)
    {
        var actionDescriptor = actionContext.ActionDescriptor;
        var controllerType = actionDescriptor.ControllerTypeInfo.AsType();
        return actionContext.HttpContext.RequestServices.GetRequiredService(controllerType);
    }
    public virtual void Release(ControllerContext context, object controller)
    {
    }
}
Register your custom resolver in the ServicesCollection
services.Replace(ServiceDescriptor.Transient<IControllerActivator, CustomControllerResolver>());
