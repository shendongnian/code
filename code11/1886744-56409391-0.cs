[AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
class TimeSeriesSerializationAttribute : Attribute
{
    public TimeSeriesSerializationType SerializationType { get; }
    public TimeSeriesSerializationAttribute(TimeSeriesSerializationType timeSeriesSerializationType)
    {
        SerializationType = timeSeriesSerializationType;
    }
}
Now you can add those above your properties just like you already wrote.  
Time for the evaluation part. You can use something like this to read all the properties and use them to serialize your TimeSeries.  
// get all public, instance properties 
IEnumerable<PropertyInfo> allProps = typeof(YourClassWithTimeSeries).GetProperties(BindingFlags.Public | BindingFlags.Instance);
// only take TimeSeries-properties
IEnumerable<PropertyInfo> timeSeriesProps = allProps.Where(p => p.PropertyType == typeof(TimeSeries));
foreach (PropertyInfo property in timeSeriesProps)
{
    // get the attribute
    TimeSeriesSerializationAttribute attribute = property.GetCustomAttribute<TimeSeriesSerializationAttribute>();
    if (attribute == null) continue; // or do something else like use a default SerializationType
    // get the value
    TimeSeries value = (TimeSeries)property.GetValue(yourInstance, null);
    // serialize using the type from the attribute
    value.Serialize(attribute.SerializationType);
}
Hope this helps you. There are also plenty of attribute tutorials and docs if you need additional information. I'll also try to answer questions you might have so feel free to ask.
