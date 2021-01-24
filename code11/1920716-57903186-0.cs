    public class CustomConverter : JsonConverter<List<SomeObject>>
    {
        public override List<SomeObject> ReadJson(JsonReader reader, Type objectType, List<SomeObject> existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            try
            {
                return serializer.Deserialize<List<SomeObject>>(reader);
            }
            catch (JsonSerializationException)
            {
                return new List<SomeObject>(); // or return null;
            }
        }
        public override void WriteJson(JsonWriter writer, List<SomeObject> value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }
    }
    public class MyModel
    {
        [JsonConverter(typeof(CustomConverter))]
        public List<SomeObject> SomeObjects { get; set; }
    }
