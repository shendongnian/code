public Task BindModelAsync(ModelBindingContext bindingContext)
{
    var targetType = bindingContext.ModelType;
    var targetName = bindingContext.ModelName;
    var stringValue = bindingContext.ValueProvider.GetValue(targetName).FirstValue;
    var isNullableOrReference = Nullable.GetUnderlyingType(targetType) != null ||
                                !targetType.IsValueType;
    var valueProvider = bindingContext.ValueProvider.GetValue(targetName);
    try
    {
        var converter = TypeDescriptor.GetConverter(targetType);
        var resultValue = converter.ConvertFromString(stringValue);
        bindingContext.Result = ModelBindingResult.Success(resultValue);
        bindingContext.ModelState.SetModelValue(targetName, valueProvider);
    }
    catch (NotSupportedException e)
    {
        bindingContext.Result = ModelBindingResult.Failed();
        return Task.CompletedTask;
    }
    catch (Exception e)
    {
        bindingContext.Result = ModelBindingResult.Success(isNullableOrReference ? null : Activator.CreateInstance(targetType));
        bindingContext.ModelState.SetModelValue(targetName, valueProvider);
    }
    return Task.CompletedTask;
}
It needs to be a bit tuned, but it works as I wanted it to be
