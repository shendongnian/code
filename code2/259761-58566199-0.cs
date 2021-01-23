    internal class SingleObjectOrArrayJsonConverter<T> : JsonConverter<ICollection<T>> where T : class, new()
    {
        public override void WriteJson(JsonWriter writer, ICollection<T> value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value.Count == 1 ? (object)value.Single() : value);
        }
        public override ICollection<T> ReadJson(JsonReader reader, Type objectType, ICollection<T> existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            return reader.TokenType switch
            {
                JsonToken.StartObject => new Collection<T> {serializer.Deserialize<T>(reader)},
                JsonToken.StartArray => serializer.Deserialize<ICollection<T>>(reader),
                _ => throw new ArgumentOutOfRangeException($"Converter does not support JSON token type {reader.TokenType}.")
            };
        }
    }
