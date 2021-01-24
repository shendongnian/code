using System.ComponentModel;
using System.Web.Mvc;
public StatusParametersModelBinder : DefaultModelBinder
{
    public override object GetPropertyValue(ControllerContext controllerContext, ModelBindingContext bindingContext, PropertyDescriptor propertyDescriptor, IModelBinder propertyBinder)
    {
        if (propertyDescriptor.ComponentType != typeof(StatusParameters))
        {
            return base.GetPropertyValue(controllerContext, bindingContext, propertyDescriptor, propertyBinder);
        }
        // Get the object and validate it
        var obj = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
        if (IsInvalid(obj))
        {
            bindingContext.ModelState.AddModelError("", "");
        }
        return obj;
    }
}
See: [System.Web.Mvc.DefaultModelBinder](https://docs.microsoft.com/en-us/dotnet/api/system.web.mvc.defaultmodelbinder?view=aspnet-mvc-5.2).
