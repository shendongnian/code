csharp
public class StrictJsonBodyModelBinder : IModelBinder
{
	public async Task BindModelAsync(ModelBindingContext bindingContext)
	{
		if (bindingContext.ModelType != typeof(string))
		{
			if (bindingContext.HttpContext.Request.ContentType != "application/json")
			{
				throw new Exception("invalid content type, application/json is expected");
			}
			using (var bodyStreamReader = new StreamReader(bindingContext.HttpContext.Request.Body))
			{
				var jsonBody = await bodyStreamReader.ReadToEndAsync().ConfigureAwait(false);
				var jsonSerializerSettings = new JsonSerializerSettings
				{
					MissingMemberHandling = MissingMemberHandling.Error,
				};
				var model = JsonConvert.DeserializeObject(jsonBody, bindingContext.ModelType, jsonSerializerSettings);
				bindingContext.Result = ModelBindingResult.Success(model);
			}
		}
	}
}
Then you could use this model binder with `ModelBinderAttribute` for specific action argument:
csharp
[HttpPost]
public JsonResult SampleMethod([ModelBinder(typeof(StrictJsonBodyModelBinder))] LoginModel prmModel)
{
}
Now, when invalid properties will be passed, `JsonConvert` will throw error (will be HTTP 500 for users if error will not be handled).
