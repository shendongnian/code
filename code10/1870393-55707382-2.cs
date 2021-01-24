    public class CurrencyJsonConverter : JsonConverter
    {
        public override bool CanWrite => true;
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Currency);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = reader.Value as string;
            return Currency.Parse(value);
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value is Currency currency)
                serializer.Serialize(writer, currency.Code);
        }
    }
