    public class OnlyBoolean : JsonConverter
    {
        readonly JsonSerializer defaultSerializer = new JsonSerializer();
    
        public override bool CanConvert(Type objectType)
        {
             return objectType.GetType() == typeof(bool);
        }
    
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
             switch (reader.TokenType)
             {
                 case JsonToken.Boolean:
                        return defaultSerializer.Deserialize(reader, objectType);
                 default:
                        throw new JsonSerializationException(string.Format("Value\"{0}\" of type {1} is not a boolean type", reader.Value, reader.TokenType));
             }
        }
    
        public override bool CanWrite { get { return false; } }
    
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
             throw new NotImplementedException();
        }
    }
