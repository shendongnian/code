    public class Vector3Converter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Vector3);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.StartObject)
            {
                JObject obj = JObject.Load(reader);
                return new Vector3((float)obj["x"], (float)obj["y"], (float)obj["z"]);
            }
            if (reader.TokenType == JsonToken.Null)
            {
                return null;
            }
            throw new JsonException("Unexpected token type: " + reader.TokenType);
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value != null)
            {
                Vector3 vector = (Vector3)value;
                JObject obj = new JObject(
                    new JProperty("x", vector.x),
                    new JProperty("y", vector.y),
                    new JProperty("z", vector.z)
                );
                obj.WriteTo(writer);
            }
            else
            {
                JValue.CreateNull().WriteTo(writer);
            }
        }
    }
