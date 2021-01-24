    public class DataConverter : JsonConverter
    {
        private int _index = 1;
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            JToken token = JToken.FromObject(value);
            token.WriteTo(writer);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JToken token = JToken.Load(reader);
            Dictionary<string, string> dict = new Dictionary<string, string>();
            try
            {
                foreach (var item in token)
                {
                    dict.Add(_index++.ToString(),  item.ToString());//Filling the data to dictionary
                }
            }
            catch
            {
                // ignored
            }
            _index = 1;//Resetting index
            return dict;
        }
        public override bool CanConvert(Type objectType)
        {
            return objectType.IsAssignableFrom(typeof(IDictionary<string, string>));
        }
    }
