    internal class LicenseeParametersModelBinder : IModelBinder
    {
        private readonly JsonSerializerOptions _jsonOpts;
        public LicenseeParametersModelBinder(IOptions<JsonSerializerOptions> jsonOpts)
        {
            this._jsonOpts = jsonOpts.Value;
        }
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var name= bindingContext.FieldName;
            var type = bindingContext.ModelType;
            try{
                var json= bindingContext.ValueProvider.GetValue(name).FirstValue;
                var obj = JsonSerializer.Deserialize(json,type, _jsonOpts);
                bindingContext.Result = ModelBindingResult.Success(obj);
            }
            catch (JsonException ex){
                bindingContext.ModelState.AddModelError(name,$"{ex.Message}");
            }
            return Task.CompletedTask;
        }
    }
    ```
    and register the model binder as below:
    ```
    [HttpGet("/api/licensee/{parameters}")]
    public IActionResult GetLicensee2([ModelBinder(typeof(LicenseeParametersModelBinder))]LicenseeParameters parameters)
    {
        return Json(parameters);
    }
    ````
    Finally, you can send a json within URL(suppose the property name is case insensive):
    ```
    GET /api/licensee/{"name":"stan","note":"it works","children":[{"nodeName":"it"},{"nodeName":"minus"}]}
    ```
