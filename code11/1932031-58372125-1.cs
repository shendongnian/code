public class YourCustomConverter : JsonConverter
{
    public override bool CanConvert(Type objectType)
    {
        return objectType.IsAssignableFrom(typeof(double));
    }
    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        try
        {
            return serializer.Deserialize<double>(reader);
        }
        catch
        {
            return 0d;
        }
    }
    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        serializer.Serialize(writer, value);
    }
}
Now you just decorate the properties you want this to be valid for with `JsonConverter`. For your example it would look like this:
public class Location
{
    public string Name { get; set; }
    [JsonConverter(typeof(YourCustomConverter))]
    public double Latitude { get; set; }
    [JsonConverter(typeof(YourCustomConverter))]
    public double Longitude { get; set; }
}
Now, if you send in invalid data, the deserializer will throw an exception, which is catched by the custom converter that returns `0` instead (or whatever value you want it to be).
**UPDATE:**
Disclaimer: This is untested!
You could probably make a generic converter to handle all cases:
public class YourCustomConverter<T> : JsonConverter
{
    public override bool CanConvert(Type objectType)
    {
        return objectType.IsAssignableFrom(typeof(T));
    }
    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        try
        {
            return serializer.Deserialize<T>(reader);
        }
        catch
        {
            return default(T);
        }
    }
    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        serializer.Serialize(writer, value);
    }
}
You could still use this as an attribute `[JsonConverter(typeof(YourCustomConverter<double>)]`.
There's also an option to use a custom converter for all JSON serialization/deserialization using this code:
services.AddMvc().AddNewtonsoftJson(options =>
{
    // Configure a custom converter
    options.SerializerOptions.Converters.Add(new SomeOtherCustomJsonConverter());
});
However, this can't really be made generic so you would have to write your own handling of all your possible types. 
