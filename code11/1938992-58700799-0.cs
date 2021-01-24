    internal class JsonFalseOrObjectConverter<T> : JsonConverter<T?> where T : class
    {
        public override T? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            ...
        }
        public override void Write(Utf8JsonWriter writer, T? value, JsonSerializerOptions options)
        {
            ...
        }
    }
