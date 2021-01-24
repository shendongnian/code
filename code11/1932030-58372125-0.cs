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
