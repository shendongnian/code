    public class ArrayToObjectConverter<T> : JsonConverter<T>
    {
        public override T Read(ref Utf8JsonReader reader, Type type, JsonSerializerOptions options)
        {
            var rootElement = JsonDocument.ParseValue(ref reader);
            // if its array return new instance or null
            if (reader.TokenType == JsonTokenType.EndArray)
            {
                // return default(T); // if you want null value instead of new instance
                return (T)Activator.CreateInstance(typeof(T));               
            }
            else
            {               
                var text = rootElement.RootElement.GetRawText();
                return JsonSerializer.Deserialize<T>(text, options); 
            }
        }
        public override bool CanConvert(Type typeToConvert)
        {
            return true;
        }       
        public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
