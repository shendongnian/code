    public class CustomBoolConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return true;
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var value = reader.Value;
            
            if (value.GetType() != typeof(bool))
            {
                throw new JsonReaderException("The JSON value could not be converted to System.Boolean.");
            }
                return value;
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value as string);
        }
    }
