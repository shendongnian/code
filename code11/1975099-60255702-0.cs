    public class ByteConverter : JsonConverter<byte[]>
    {
        public override byte[] ReadJson(JsonReader reader, Type objectType, byte[] existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            switch (reader.MoveToContentAndAssert().TokenType) // Skip past comments
            {
                case JsonToken.Null:
                    return null;
                case JsonToken.String:
                case JsonToken.Bytes:
                    return (byte [])JToken.Load(reader);
                case JsonToken.StartArray:
                    // Your custom logic here
                default:
                    throw new JsonSerializationException(string.Format("Unexpected token {0}", reader.TokenType));
            }
        }
        // Remainder omitted
