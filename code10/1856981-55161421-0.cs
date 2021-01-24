xml
  <ItemGroup>
    <PackageReference Include="Newtonsoft.Json" Version="12.0.1" />
  </ItemGroup>
and then register a `JsonLoadSettings` option as a singleton service for later reuse :
csharp
services.AddSingleton<JsonLoadSettings>(sp =>{
    return new JsonLoadSettings { 
        DuplicatePropertyNameHandling =  DuplicatePropertyNameHandling.Error,
    };
});
Now we can create a custom model binder to deal with duplicated properties :
csharp
public class XJsonModelBinder: IModelBinder
{
    private JsonLoadSettings _loadSettings;
    public XJsonModelBinder(JsonLoadSettings loadSettings)
    {
        this._loadSettings = loadSettings;
    }
    public Task BindModelAsync(ModelBindingContext bindingContext)
    {
        if (bindingContext == null) { throw new ArgumentNullException(nameof(bindingContext)); }
        var modelName = bindingContext.BinderModelName?? "XJson";
        var modelType = bindingContext.ModelType;
        // create a JsonTextReader
        var req = bindingContext.HttpContext.Request;
        var raw= req.Body;
        if(raw == null){ 
            bindingContext.ModelState.AddModelError(modelName,"invalid request body stream");
            return Task.CompletedTask;
        }
        JsonTextReader reader = new JsonTextReader(new StreamReader(raw));
        // binding 
        try{
            var json= (JObject) JToken.Load(reader,this._loadSettings);
            var o  = json.ToObject(modelType);
            bindingContext.Result = ModelBindingResult.Success(o);
        }catch(Exception e){
            bindingContext.ModelState.AddModelError(modelName,e.ToString()); // you might want to custom the error info
            bindingContext.Result = ModelBindingResult.Failed();
        }
        return Task.CompletedTask;
    }
}
To enable read the `Request.Body` multiple times, we could also create a dummy `Filter`:
public class EnableRewindResourceFilterAttribute : Attribute, IResourceFilter
{
    public void OnResourceExecuting(ResourceExecutingContext context)
    {
        context.HttpContext.Request.EnableRewind();
    }
    public void OnResourceExecuted(ResourceExecutedContext context) { }
}
Lastly, decorate the action method with `[ModelBinder(typeof(XJsonModelBinder))]` and `EnableRewindResourceFilter`:
csharp
    [HttpPost]
    [EnableRewindResourceFilter]
    public JsonResult GetAnswer([ModelBinder(typeof(XJsonModelBinder))]SampleModel question)
    {               
        if(ModelState.IsValid){
            return Json(question.Answer);
        }
        else{
            // ... deal with invalid state
        }
    }
Demo :
[![enter image description here][1]][1]
  [1]: https://i.stack.imgur.com/SXBqv.png
