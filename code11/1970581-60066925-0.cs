    void Initialize()
    {
        JsonConvert.DefaultSettings = () => new JsonSerializerSettings
        {
            Converters = new List<JsonConverter>
            {
                new BoolJsonConverter()
            }
        };
    }
    // Create JsonConvert you want to add to DefaultSettings
    public class BoolJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(bool);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
        }
    }
    var json = @"{""flag"":123}"
    var myClass = JsonConvert.DeserializeObject<MyClass>(json);
