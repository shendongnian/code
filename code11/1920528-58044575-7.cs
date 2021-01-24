    public class CustomEnumConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            var type = IsNullableType(objectType) ? Nullable.GetUnderlyingType(objectType) : objectType;
            return type != null && type.IsEnum;
        }
    
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var isNullable = IsNullableType(objectType);
            var enumType = isNullable ? Nullable.GetUnderlyingType(objectType) : objectType;
            var names = Enum.GetNames(enumType ?? throw new InvalidOperationException());
    
            if (reader.TokenType != JsonToken.String) return null;
            var enumText = reader.Value.ToString();
    
            if (string.IsNullOrEmpty(enumText)) return null;
            var match = names.FirstOrDefault(e => string.Equals(e, enumText, StringComparison.OrdinalIgnoreCase));
    
            return match != null ? Enum.Parse(enumType, match) : null;
        }
    
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue(value.ToString());
        }
    
        public override bool CanWrite => true;
    
        private static bool IsNullableType(Type t)
        {
            return (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Nullable<>));
        }
    }
