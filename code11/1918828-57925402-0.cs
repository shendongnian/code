using Microsoft.AspNetCore.Mvc.ModelBinding;
// in my custom binder class derived from IModelBinder
public async Task BindModelAsync(ModelBindingContext bindingContext)
{
  var compositeValueProvider = bindingContext.ValueProvider as CompositeValueProvider;
  // For unprefixed names:
  // This also returns prefixes of prefixed names so you can recursively find the names
  var callerProvidedKeys = compositeValueProvider.GetKeysFromPrefix(""); 
  // or for a known prefix name
  //var callerProvidedKeys = compositeValueProvider.GetKeysFromPrefix(somePrefix);
  foreach (KeyValuePair<string, string> kvp in callerProvidedKeys) {
    // You can but don't have to access values through `CompositeValueProvider`
    var valueProviderResult = bindingContext.ValueProvider.GetValue(kvp.Value);
  }
  ...
}
`GetKeysFromPrefix` returns `IDictionary<string,string>` where keys are the name portion only, and the value being the full parameter name including prefix.  The full name can then be used to extract the parameter value. 
