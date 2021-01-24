    public class ArrayConverter : JsonConverter
    {
        private readonly string _propertyName;
        public ArrayConverter(string propertyName)
        {
            this._propertyName = propertyName;
        }
        public override bool CanConvert(Type objectType)
        {
            return objectType.IsArray || (objectType.IsGenericType && objectType.GetGenericTypeDefinition() == typeof(List<>));
        }
        public override bool CanRead => false;
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value is IEnumerable enumerableValue)
            {
                JObject obj = new JObject();
                writer.WriteStartObject();
                foreach (var val in enumerableValue)
                {
                    writer.WritePropertyName(_propertyName);
                    writer.WriteToken(JToken.FromObject(val, serializer).CreateReader());
                }
                writer.WriteEndObject();
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(value), "Value does not implement IEnumerable.");
            }
        }
    }
