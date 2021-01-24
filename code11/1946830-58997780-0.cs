c#
public class KeyValueListModelBinder : IModelBinder
{
    public Task BindModelAsync(ModelBindingContext bindingContext)
    {
        var key = bindingContext.ModelName;
        var jsonString = bindingContext.ValueProvider.GetValue(key).FirstValue;
        MyCustomModel result = JsonConvert.DeserializeObject<IEnumerable<KeyValuePair<string, string>>>(jsonString);
        bindingContext.Result = ModelBindingResult.Success(result);
        return Task.CompletedTask;
    }
}
Create the provider:
c#
public class KeyValueListModelBinderProvider : IModelBinderProvider
{
    public IModelBinder GetBinder(ModelBinderProviderContext context)
    {
        if (context.Metadata.ModelType == typeof(List<KeyValuePair<string, string>>))
            return new KeyValueListModelBinder();
        return null;
    }
}
Register the provider in startup:
c#
public void ConfigureServices(IServiceCollection services)
{
    services.AddMvc(config => config.ModelBinderProviders.Insert(0, new KeyValueListModelBinderProvider()));
}
