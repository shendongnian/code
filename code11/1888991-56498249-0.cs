 csharp
// generic array model binder
public class ArrayModelBinder<TType> : IModelBinder {
    public Task BindModelAsync(ModelBindingContext bindingContext) {
        if (bindingContext.ModelMetadata.IsEnumerableType) {
            var value = bindingContext.ValueProvider.GetValue(bindingContext.ModelName).ToString();
            if (!string.IsNullOrEmpty(value)) {
                var elementType = typeof(TType); 
                var typeConverter = TypeDescriptor.GetConverter(elementType);
                var splittedValues = value.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                var values = splittedValues.Select(t => typeConverter.ConvertFromString(t.Trim())).ToArray();
                var typedValues = Array.CreateInstance(elementType, values.Length);
                values.CopyTo(typedValues, 0);
                bindingContext.Model = typedValues;
                return SuccessBinding(bindingContext, typedValues);
            }
            return SuccessBinding(bindingContext, null);
        }
        return FailedBinding(bindingContext);
    }
    private static Task SuccessBinding(ModelBindingContext bindingContext, Array typedValues) {
        bindingContext.Result = ModelBindingResult.Success(typedValues);
        return Task.CompletedTask;
    }
    private static Task FailedBinding(ModelBindingContext bindingContext) {
        bindingContext.Result = ModelBindingResult.Failed();
        return Task.CompletedTask;
    }
To use it on your Action you'll just have to use this piece of code:
chsarp
public async Task<IActionResult> GetMarketData([ModelBinder(BinderType = typeof(ArrayModelBinder<object>))] MyObject[] queryData)
{
    return this.Ok(0);
}
I have the source of this implementation and other things in a repo of my own Library feel free to check it out [CcLibrary.AspNetCore](https://github.com/carlos-chourio/CcLibrary.AspNetCore)
