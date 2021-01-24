cs
public class OnOffStringToBoolConverter : JsonConverter
{
    private readonly Type _sourceType = typeof(string);
    private readonly Type _targetType = typeof(bool);
    public OnOffStringToBoolConverter()
    {
    }
    public override bool CanRead => true;
    public override bool CanWrite => true;
    public override bool CanConvert(Type objectType)
    {
        if (objectType == null)
        {
            throw new ArgumentNullException(nameof(objectType));
        }
        return objectType == _sourceType;
    }
    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        if (reader == null)
        {
            throw new ArgumentNullException(nameof(reader));
        }
        if (objectType == null)
        {
            throw new ArgumentNullException(nameof(objectType));
        }
        if (serializer == null)
        {
            throw new ArgumentNullException(nameof(serializer));
        }
        if (reader.Value == null)
        {
            // Add some null handling logic here if needed.
            throw new JsonSerializationException(
                $"Unable to deserialize null value to {_targetType.Name}.");
        }
        if (string.Compare(reader.Value.ToString(), "On", StringComparison.OrdinalIgnoreCase) == 0)
        {
            return true;
        }
        if (string.Compare(reader.Value.ToString(), "Off", StringComparison.OrdinalIgnoreCase) == 0)
        {
            return false;
        }
        throw new JsonSerializationException(
            $"Unable to deserialize '{reader.Value}' to {_targetType.FullName}. " +
            $"This converter supports only \"On\", \"Off\" values.");
    }
    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        if (writer == null)
        {
            throw new ArgumentNullException(nameof(writer));
        }
        if (serializer == null)
        {
            throw new ArgumentNullException(nameof(serializer));
        }
        if (value == null)
        {
            // Add some null handling logic here if needed.
            throw new JsonSerializationException("Unable to serialize null value.");
        }
        // Write value only if it is boolean type.
        if (value is bool boolValue)
        {
            writer.WriteValue(boolValue ? "On" : "Off");
        }
        else
        {
            throw new JsonSerializationException(
                $"Unable to serialize '{value}' of type {value.GetType().FullName}. " +
                $"This converter supports deserialization of values " +
                $"of {_targetType.FullName} type only.");
        }
    }
}
