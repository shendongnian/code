    public class CustomConverter : JsonConverter<BaseClass>
    {
        private readonly JsonSerializerOptions _serializerOptions;
        public CustomConverter()
        {
            _serializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                IgnoreNullValues = true,
            };
        }
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(BaseClass));
        }
        public override BaseClass Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
        public override void Write(Utf8JsonWriter writer, BaseClass value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(JsonSerializer.SerializeToUtf8Bytes(value, value.GetType(), _serializerOptions));
        }
    }
