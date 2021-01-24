    internal sealed class TrimmedStringCollectionConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType.IsArray && objectType.GetElementType() == typeof(string);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (existingValue is null)
            {
                 // Returning empty array.
                 return new string[0];
            }
            var array = (string[])existingValue;
            return array.Where(s => !String.IsNullOrEmpty(s)).ToArray();
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue(value);
        }
    }
