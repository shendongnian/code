    public class ObjectToListConverter<T> : JsonConverter
    {
        public string KeyPropertyName { get; set; }
        public ObjectToListConverter(string keyPropertyName)
        {
            KeyPropertyName = keyPropertyName;
        }
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(List<T>);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject obj = JObject.Load(reader);
            List<T> list = new List<T>();
            foreach (JProperty prop in obj.Properties().Where(p => p.Value.Type == JTokenType.Object))
            {
                JToken item = prop.Value;
                item[KeyPropertyName] = prop.Name;
                list.Add(item.ToObject<T>(serializer));
            }
            return list;
        }
        public override bool CanWrite { get { return false; } }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
