public class ErrorIgnoringJsonConverter<T> : JsonConverter<T>
{
    public override bool CanWrite => false;
    public override bool CanRead => true;
    public override T ReadJson(JsonReader reader, Type objectType, T existingValue, bool hasExistingValue, JsonSerializer serializer)
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
    public override void WriteJson(JsonWriter writer, T value, JsonSerializer serializer)
    {
        throw new NotImplementedException();
    }
}
What you do with this converter doesn't matter. One possible solution which will work is the one OP posted already - I don't see any issues with this approach.
services
    .AddMvc()
    .AddNewtonsoftJson(options =>
        {
            options.SerializerSettings.Converters.Add(new ErrorIgnoringJsonConverter<bool>());
            options.SerializerSettings.Converters.Add(new ErrorIgnoringJsonConverter<int>());
            options.SerializerSettings.Converters.Add(new ErrorIgnoringJsonConverter<long>());
            options.SerializerSettings.Converters.Add(new ErrorIgnoringJsonConverter<float>());
            options.SerializerSettings.Converters.Add(new ErrorIgnoringJsonConverter<double>());
            options.SerializerSettings.Converters.Add(new ErrorIgnoringJsonConverter<decimal>());
            options.SerializerSettings.Converters.Add(new ErrorIgnoringJsonConverter<DateTime>());
        });
