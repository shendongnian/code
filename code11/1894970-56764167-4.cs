    public class ArrayConverter : JsonConverter
    {
        private readonly string _propertyName;
        public ArrayConverter(string propertyName)
        {
            this._propertyName = propertyName;
        }
        public override bool CanConvert(Type objectType)
        {
            return objectType.IsGenericType && objectType.GetGenericTypeDefinition() == typeof(List<>);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
            {
                return null;
            }
            IList items = (IList)Activator.CreateInstance(objectType);
            var modelType = objectType.IsArray ? objectType.GetElementType() : objectType.GetGenericArguments().Single();
            if (reader.TokenType != JsonToken.StartObject)
            {
                throw new ArgumentOutOfRangeException(nameof(reader), "Expected object.");
            }
            while (reader.Read() && reader.TokenType != JsonToken.EndObject)
            {
                reader.Read();
                items.Add(serializer.Deserialize(reader, modelType));
            }
            return items;
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
                    serializer.Serialize(writer, val);
                }
                writer.WriteEndObject();
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(value), "Value does not implement IEnumerable.");
            }
        }
    }
