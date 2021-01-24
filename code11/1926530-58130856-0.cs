c#
// Assume that 'event' is an instance of EventTO
foreach (var propertyName in propsList)
{
    object value = event.GetType().GetProperty(propertyName).GetValue(event, null);
    // Do whatever with 'value'
}
As you can see we have some redundant code (GetType and GetProperty), so instead of storing our properties as a string of their names in a list, we can store the PropertyInfo in a and use it like so:
c#
var propsList = typeof(EventTO).GetProperties();
foreach (var property in propsList)
{
    object value = property.GetValue(event, null);
}
