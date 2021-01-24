    public class NonEmptyStringConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType) => objectType == typeof(string);
        
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            => throw new NotImplementedException();
    
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType != JsonToken.String)
                throw CreateException($"Expected string value, but found {reader.TokenType}.", reader);
    
            var value = (string)reader.Value;
    
            if (String.IsNullOrEmpty(value))
                throw CreateException("Non-empty string required.", reader);
    
            return value;
        }
      
        private static Exception CreateException(string message, JsonReader reader)
        {
            var info = (IJsonLineInfo)reader;
            return new JsonSerializationException(
                $"{message} Path '{reader.Path}', line {info.LineNumber}, position {info.LinePosition}.",
                reader.Path, info.LineNumber, info.LinePosition, null);
        }
    }
