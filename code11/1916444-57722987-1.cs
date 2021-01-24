    public class SingleElementArrayJsonConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            string[] arr = value as string[];
            if (arr == null)
            {
                throw new ArgumentNullException(nameof(value));
            }
            if(arr.Length == 1)
            {
                JToken.FromObject(arr[0]).WriteTo(writer);
            }
            else
            {
                JArray.FromObject(arr).WriteTo(writer);
            }
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
        public override bool CanWrite => true;
        public override bool CanRead => false;
        public override bool CanConvert(Type objectType) => objectType == typeof(string[]);
    }
This Converter should be used like this:
string serialized = JsonConvert.SerializeObject(dict, new SingleElementArrayJsonConverter());
