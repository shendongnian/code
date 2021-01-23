    internal class StringOrInnerConverter : JsonConverter {
        public override bool CanConvert(Type objectType) {
            return objectType == typeof(Inner);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) {
            var ser = new JsonSerializer();
            if (reader.TokenType == JsonToken.StartObject) {
                var inn = ser.Deserialize<Inner>(reader);
                return inn;
            } else if (reader.TokenType == JsonToken.String) {
                var str = ser.Deserialize<string>(reader);
                return (Inner)str; // Or however you want to convert string to Inner
            } else {
                return default(Inner);
            }
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) {
            throw new System.NotImplementedException();
        }
    }
