    public class TypeSafeEnumJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            var types = new[] { typeof(TypeSafeEnumBase) };
            return types.Any(t => t == objectType);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            string name = objectType.Name;
            string value = serializer.Deserialize(reader).ToString();
            return TypeSafeEnumConversion.ConvertToTypeSafeEnum(name, value); // call to our type safe converter
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value == null && serializer.NullValueHandling == NullValueHandling.Ignore)
            {
                return;
            }
            writer.WriteValue(value?.ToString());
        }
    }
