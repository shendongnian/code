c#
public class MyBinder : IModelBinderProvider, IModelBinder
{
    public IModelBinder GetBinder(ModelBinderProviderContext context) =>
        (context.Metadata.ModelType == typeof(string)) ? this : null;
    public Task BindModelAsync(ModelBindingContext bindingContext)
    {
            var value = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            if (value != ValueProviderResult.None)
            {
                bindingContext.ModelState.SetModelValue(bindingContext.ModelName, value);
                var str = value.FirstValue;
                if (bindingContext.ModelMetadata.ConvertEmptyStringToNull && string.IsNullOrWhiteSpace(str))
                    str = null;
                // TODO strip out invalid characters here
                bindingContext.Result = ModelBindingResult.Success(str);
            }
            return Task.CompletedTask;
    }
}
options.ModelBinderProviders.Insert(0, new MyBinder());
If you want to return failure instead of silently modifying strings. You could either implement a validation attribute and remember to use it everywhere...
Or implement `IModelValidatorProvider` and add your `IModelValidator` to each bound string value.
