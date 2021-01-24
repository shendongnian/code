    public class ByteConverter : JsonConverter<byte[]>
    {
        public override byte[] ReadJson(JsonReader reader, Type objectType, byte[] existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            switch (reader.MoveToContentAndAssert().TokenType) // Skip past comments
            {
                case JsonToken.Null:
                    return null;
                case JsonToken.StartArray:
                    // Your custom logic here, e.g.:
                    return serializer.Deserialize<List<byte>>(reader).ToArray();
                default:
                    return (byte[])JToken.Load(reader);
            }
        }
        // Remainder omitted
