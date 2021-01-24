    public class BsonToJsonConverter : JsonConverter<BsonDocument>
    {
        public override BsonDocument ReadJson(JsonReader reader, Type objectType, BsonDocument existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            JToken token = JToken.Load(reader);
            return BsonDocument.Parse(token.ToString());
        }
        public override void WriteJson(JsonWriter writer, BsonDocument value, JsonSerializer serializer)
        {
            writer.WriteRawValue(value.ToJson());
        }
    }
