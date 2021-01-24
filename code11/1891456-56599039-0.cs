    public class OneWayStringConverter : JsonConverter {
      public override bool CanConvert(Type objectType) {
        return true;
      }
      public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) {
        throw new InvalidOperationException("This one-way converter cannot be used for deserialization.");
      }
      public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) {
        writer.WriteValue(value.ToString());
      }
    }
