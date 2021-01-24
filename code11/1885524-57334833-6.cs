public class LongToStringConverter : JsonConverter<long>
{
    public override long Read(ref Utf8JsonReader reader, Type type, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.String)
        {
            // try to parse number directly from bytes
            ReadOnlySpan<byte> span = reader.HasValueSequence ? reader.ValueSequence.ToArray() : reader.ValueSpan;
            if (Utf8Parser.TryParse(span, out long number, out int bytesConsumed) && span.Length == bytesConsumed)
                return number;
            // try to parse from a string if the above failed, this covers cases with other escaped/UTF characters
            if (Int64.TryParse(reader.GetString(), out number))
                return number;
        }
        // fallback to default handling
        return reader.GetInt64();
    }
    public override void Write(Utf8JsonWriter writer, long value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString());
    }
}
Register the converter by adding it to the `Converters` list in `JsonSerializerOptions`
services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new LongToStringConverter());
});
*Note: The current release doesn't support nullable types yet.*
  [1]: https://docs.microsoft.com/en-us/dotnet/api/system.text.json.serialization.jsonconverterattribute?view=netcore-3.0
