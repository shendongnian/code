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
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var items = new List<JToken>();
            if (reader.TokenType != JsonToken.StartObject)
            {
                throw new ArgumentOutOfRangeException(nameof(reader), "Expected object.");
            }
            while (reader.Read() && reader.TokenType != JsonToken.EndObject)
            {
                reader.Read();
                items.Add(JToken.ReadFrom(reader));
            }
            using (var arrayReader = JArray.FromObject(items).CreateReader())
            {
                return serializer.Deserialize(arrayReader, objectType);
            }
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
                    using (var reader = JToken.FromObject(val, serializer).CreateReader())
                    {
                        writer.WriteToken(reader);
                    }
                }
                writer.WriteEndObject();
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(value), "Value does not implement IEnumerable.");
            }
        }
    }
