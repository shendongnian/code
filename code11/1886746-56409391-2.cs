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
By the way if the attribute you get turns out as null, the attribute just isn't set. You can either skip the property entirely or use a default SerializationType, whatever you need/want.  
public static void SerializeToSomewhere(YourClassWithTimeSeries instance) {
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
        TimeSeries value = (TimeSeries)property.GetValue(instance, null);
        // serialize using the type from the attribute
        string serializedValue = value.Serialize(attribute.SerializationType);
        // Do whatever with the serialized value (for example save it to a file or whatever)
    }
}
Hope this helps you. There are also plenty of attribute tutorials and docs if you need additional information. I'll also try to answer questions you might have so feel free to ask.  
Edit:  
Small thing to add. In your code your TimeSeries-class exposes the public fields Times and Values. You shouldn't do that. 
Instead of doing this:  
public List<DateTime> Times = new List<DateTime>();
public List<decimal> Values = new List<decimal>();
You should do this. It stops you from accidentally assigning it again from within or outside the class. 
public List<DateTime> Times { get; } = new List<DateTime>();
public List<decimal> Values { get; } = new List<decimal>();
