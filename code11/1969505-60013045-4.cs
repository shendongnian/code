    public class ArrayToObjectConverter<T> : JsonConverter
    {
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JToken token = JToken.Load(reader);
            if (token.Type == JTokenType.Array)
            {
                // this returns null (default(SomeObject) in your case)
                // if you want a new instance return (T)Activator.CreateInstance(typeof(T)) instead
                return default(T);
            }
            return token.ToObject<T>();
        }
        public override bool CanConvert(Type objectType)
        {
            return true;
        }
        public override bool CanWrite
        {
            get { return true; }  
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }
    }
