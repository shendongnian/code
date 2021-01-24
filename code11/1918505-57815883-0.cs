xml
<PackageReference Include="Newtonsoft.Json" Version="12.0.1" />
And then create a custom Model Binder to handle duplicated keys:
csharp
public class RejectDuplicatedKeysModelBinder : IModelBinder
{
    private JsonLoadSettings _loadSettings  = new JsonLoadSettings(){ DuplicatePropertyNameHandling = DuplicatePropertyNameHandling.Error };
    public Task BindModelAsync(ModelBindingContext bindingContext)
    {
        if (bindingContext == null) { throw new ArgumentNullException(nameof(bindingContext)); }
        var modelName = bindingContext.BinderModelName ?? bindingContext.OriginalModelName ?? bindingContext.FieldName ?? String.Empty;
        var modelType = bindingContext.ModelType;
        var req = bindingContext.HttpContext.Request;
        var raw = req.Body;
        if (raw == null) {
            bindingContext.ModelState.AddModelError(modelName, "invalid request body stream");
            return Task.CompletedTask;
        }
        JsonTextReader reader = new JsonTextReader(new StreamReader(raw));
        try {
            var json = (JObject)JToken.Load(reader, this._loadSettings);
            var o = json.ToObject(modelType);
            bindingContext.Result = ModelBindingResult.Success(o);
        }
        catch (JsonReaderException e) {
            var msg = $"wrong property with key='{e.Path}': {e.Message}";
            bindingContext.ModelState.AddModelError(modelName, msg); 
            bindingContext.Result = ModelBindingResult.Failed();
        } 
        catch(Exception e) {
            bindingContext.ModelState.AddModelError(modelName, e.ToString()); // you might want to custom the error info
            bindingContext.Result = ModelBindingResult.Failed();
        }
        return Task.CompletedTask;
    }
}
By this way, the duplicated error info will be added into `ModelState`.
**Test Case**
Let's create a action method for test:
csharp
[HttpPost]
public IActionResult Test([ModelBinder(typeof(RejectDuplicatedKeysModelBinder))]XModel model){
    if(! this.ModelState.IsValid){
        var problemDetails = new ValidationProblemDetails(this.ModelState)
        {
            Status = StatusCodes.Status400BadRequest,
        };
        return BadRequest(problemDetails);
    }
    return new JsonResult(model);
}
When there's a json with duplicated keys, we'll get an error like:
[![enter image description here][1]][1]
  [1]: https://i.stack.imgur.com/67GQR.png
