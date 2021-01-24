c#
// this binder assigns form fields with dots to properties with underscores:
// e.g. data.json -> data_json
public class Dot2UnderscoreModelBinder : IModelBinder
{
    // for regular fields, we will use the default binder 
    private readonly DefaultModelBinder _default = new DefaultModelBinder();
    public object BindModel(
        ControllerContext controllerContext, 
        ModelBindingContext bindingContext)
    {
        // handle the regular fields
        var model = _default.BindModel(controllerContext, bindingContext);
        // handle the special fields
        if (model != null)
        {
            var modelType = model.GetType();
            var form = controllerContext.HttpContext.Request.Form;
            foreach (var key in form.AllKeys)
            {
                if (key.Contains(".")) // special field
                {
                    // model property must be named by the convention "." -> "_" 
                    var propertyName = key.Replace(".", "_");
                    var propertyInfo = modelType.GetProperty(propertyName);
                    propertyInfo?.SetValue(model, form[key]);
                }
            }
        }
        return model;
    }
}
Note that this is a simplistic implementation, it only supports `string` properties, and its performance is not optimal. But it is a working starting point. 
Now you need to apply the above binder to the model class:
c#
[ModelBinder(typeof(Dot2UnderscoreModelBinder))]
public class Lead 
{
    //... properties
}
It worth noting that the controller must derive from [`Controller`](https://docs.microsoft.com/en-us/dotnet/api/system.web.mvc.controller?view=aspnet-mvc-5.2) in `System.Web.Mvc` namespace, and not `ApiController` in `System.Web.Http`, because that latter doesn't trigger model binders.
### ASP.NET Core
Just as a side note, in ASP.NET Core the same can be achieved in a very simple way, by applying [`FromForm`](https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.fromformattribute?view=aspnetcore-2.2) attribute:
c#
public class Lead 
{
    [FromForm(Name = "data.json")] // apply this attribute
    public string data_json { get; set; }
    //... other properties
}
