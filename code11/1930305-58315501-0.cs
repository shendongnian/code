c#
internal class FromTempDataAttribute : Attribute, IBindingSourceMetadata
{
    public static readonly BindingSource Instance = new BindingSource(
            "id-FromTempData",
            "TempData Binding Source",
            true,
            true
        );
    public BindingSource BindingSource {get{
        return FromTempDataAttribute.Instance;
    }} 
}
And then create a ModelBinder and a related Provider:
c#
public class MyFromTempDataModelBinder : IModelBinder
{
    private readonly IServiceProvider sp;
    public MyFromTempDataModelBinder(IServiceProvider sp)
    {
        this.sp = sp;
    }
    public Task BindModelAsync(ModelBindingContext bindingContext)
    {
        var factory = this.sp.GetRequiredService<ITempDataDictionaryFactory>();
        var tempData = factory.GetTempData(bindingContext.HttpContext);
        var name = bindingContext.FieldName;
        var o = tempData.Peek(name);
        if (o == null) {
            bindingContext.ModelState.AddModelError(name, $"cannot get {name} from TempData");
        } else {
            var result = Convert.ChangeType(o,bindingContext.ModelType);
            bindingContext.Result = ModelBindingResult.Success(result);
        }
        return Task.CompletedTask;
    }
}
public class FromTempDataBinderProvider : IModelBinderProvider
{
    public IModelBinder GetBinder(ModelBinderProviderContext context)
    {
        if (context == null) { throw new ArgumentNullException(nameof(context)); }
        var has = context.BindingInfo?.BindingSource == FromTempDataAttribute.Instance;
        if(has){
            return new BinderTypeModelBinder(typeof(MyFromTempDataModelBinder));
        }
        return null;
    }
}
The Provider returns an instance of `MyFromTempDataModelBinder` if the `context.BindingInfo.BindingSource` equals the required attribute.
Also don't forget to register this provider in your startup:
c#
services.AddMvc(opts => {
    opts.ModelBinderProviders.Insert(0, new FromTempDataBinderProvider());
}).SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
Finally, you can get the data automatically:
public IActionResult Test([FromTempDataAttribute] string a, string b )
{
    return Json(new {A = a, B = b,});
}
## Approach 2
In case you insist on Filter, you can also make the `FromTempDataAttribute` implement the `IBindingSourceMetadata` interface as we do above, and then you can get those parameters as below:
    public class TempDataActionFilter : IAsyncActionFilter
    {
        public Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var parameteres = context.ActionDescriptor.Parameters.Where(p => p.BindingInfo?.BindingSource == FromTempDataAttribute.Instance);
            foreach(var p in parameteres){
                // ...
            }
            return next();
        }
    }
