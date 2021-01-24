    public class CustomCarConverter : JsonConverter<Car>
    {
        Dictionary<string, Brand> _brands;
        public CustomCarConverter(Dictionary<string, Brand> brands)
        {
            _brands = brands;
        }
        public override bool CanWrite => false;
        public override void WriteJson(JsonWriter writer, Car value, JsonSerializer serializer) => throw new NotImplementedException();
        public override Car ReadJson(JsonReader reader, Type objectType, Car existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            JObject obj = (JObject)serializer.Deserialize(reader);
            return new Car()
            {
                Id = obj.GetValue("Id").Value<int>(),
                Name = obj.GetValue("Name").Value<string>(),
                Brand = _brands[obj.GetValue("Brand").Value<string>()]
            };
        }
    }
