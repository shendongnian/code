    public class Item
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("group")]
        [JsonConverter(typeof(ObjectToValueConverter))]
        public int GroupId { get; set; }
    }
    class ObjectToValueConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType) => true;
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var token = JToken.Load(reader);
            if (token.Type == JTokenType.Object && ((JObject)token).ContainsKey("id")) {
                return (int)token["id"];
            }
            return 0;
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) 
            => throw new NotImplementedException();
    }
