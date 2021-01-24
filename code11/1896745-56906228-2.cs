void PopulateObject<T>(T target, string jsonSource) where T : class
We don't really want any custom parsing as it's cumbersome, so we'll try the obvious approach - deserialize `jsonSource` and copy the result properties into our object. We cannot, however, just go
T updateObject = JsonSerializer.Parse<T>(jsonSource);
CopyUpdatedProperties(target, updateObject);
That's because for a type
class Example
{
    int Id { get; set; }
    int Value { get; set; }
}
and a JSON
{
    "Id": 42
}
we will get `updateObject.Value == 0`. Now we don't know if `0` is the new updated value or if it just wasn't updated, so we need to know exactly which properties `jsonSource` contains.
Fortunately, the `System.Text.Json` API allows us to examine the structure of the parsed JSON.
var json = JsonDocument.Parse(jsonSource).RootElement;
We can now enumerate over all properties and copy them.
foreach (var property in json.EnumerateObject())
{
    OverwriteProperty(target, property);
}
We will copy the value using reflection:
void OverwriteProperty<T>(T target, JsonProperty updatedProperty) where T : class
{
    var propertyInfo = typeof(T).GetProperty(updatedProperty.Name);
    if (propertyInfo == null)
    {
        return;
    }
    var propertyType = propertyInfo.PropertyType;
    var parsedValue = JsonSerializer.Parse(updatedProperty.Value, propertyType);
    propertyInfo.SetValue(target, parsedValue);
} 
We can see here that what we're doing is a _shallow_ update. If the object contains another complex object as its property, that one will be copied and overwritten as a whole, not updated. If you require _deep_ updates, this method needs to be changed to extract the current value of the property and then call the `PopulateObject` recursively if the property's type is a reference type (that will also require accepting `Type` as a parameter in `PopulateObject`). 
Joining it all together we get:
void PopulateObject<T>(T target, string jsonSource) where T : class
{
    var json = JsonDocument.Parse(jsonSource).RootElement;
    foreach (var property in json.EnumerateObject())
    {
        OverwriteProperty(target, property);
    }
}
void OverwriteProperty<T>(T target, JsonProperty updatedProperty) where T : class
{
    var propertyInfo = typeof(T).GetProperty(updatedProperty.Name);
    if (propertyInfo == null)
    {
        return;
    }
    var propertyType = propertyInfo.PropertyType;
    var parsedValue = JsonSerializer.Parse(updatedProperty.Value, propertyType);
    propertyInfo.SetValue(target, parsedValue);
} 
How robust is this? Well, it certainly won't do anything sensible for a JSON array, but I'm not sure how you'd expect a `PopulateObject` method to work on an array to begin with. I don't know how it compares in performance to the `Json.Net` version, you'd have to test that by yourself. It also silently ignores properties that are not in the target type, by design. I thought it was the most sensible approach, but you might think otherwise, in that case the property null-check has to be replaced with an exception throw.
**EDIT:**
I went ahead and implemented a deep copy:
void PopulateObject<T>(T target, string jsonSource) where T : class => 
    PopulateObject(target, jsonSource, typeof(T));
void OverwriteProperty<T>(T target, JsonProperty updatedProperty) where T : class =>
    OverwriteProperty(target, updatedProperty, typeof(T));
void PopulateObject(object target, string jsonSource, Type type)
{
    var json = JsonDocument.Parse(jsonSource).RootElement;
    foreach (var property in json.EnumerateObject())
    {
        OverwriteProperty(target, property, type);
    }
}
void OverwriteProperty(object target, JsonProperty updatedProperty, Type type)
{
    var propertyInfo = type.GetProperty(updatedProperty.Name);
    if (propertyInfo == null)
    {
        return;
    }
    var propertyType = propertyInfo.PropertyType;
    object parsedValue;
    if (propertyType.IsValueType)
    {
        parsedValue = JsonSerializer.Parse(updatedProperty.Value, propertyType);
    }
    else
    {
        parsedValue = propertyInfo.GetValue(target);
        PopulateObject(parsedValue, updatedProperty.Value, propertyType);
    }
    propertyInfo.SetValue(target, parsedValue);
}
To make this more robust you'd either have to have a separate `PopulateObjectDeep` method or pass `PopulateObjectOptions` or something similar with a deep/shallow flag.
**EDIT 2:**
The point of deep-copying is so that if we have an object
{
    "Id": 42,
    "Child":
    {
        "Id": 43,
        "Value": 32
    },
    "Value": 128
}
and populate it with
{
    "Child":
    {
        "Value": 64
    }
}
we'd get
{
    "Id": 42,
    "Child":
    {
        "Id": 43,
        "Value": 64
    },
    "Value": 128
}
In case of a shallow copy we'd get `Id = 0` in the copied child.
