    public class ErrorIgnoringJsonConverter<T> : JsonConverter<T>
    {
        public override bool CanWrite => false;
        public override T ReadJson(JsonReader reader, Type objectType, T existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            try
            {
                return (T)Convert.ChangeType(reader.Value, typeof(T));
            }
            catch (Exception)
            {
                return Activator.CreateInstance<T>();
            }
        }
        public override void WriteJson(JsonWriter writer, T value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
