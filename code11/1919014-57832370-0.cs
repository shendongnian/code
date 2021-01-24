       public class NullGuidJsonConverter : JsonConverter<Guid>
       {
          public override void WriteJson(JsonWriter writer, Guid value, JsonSerializer serializer)
          {
             writer.WriteValue(value == Guid.Empty ? null : value.ToString());
          }
    
          public override Guid ReadJson(JsonReader reader, Type objectType, Guid existingValue, bool hasExistingValue, JsonSerializer serializer)
          {
             var value = reader.Value.ToString();
             return value == "null" ? Guid.Empty : Guid.Parse(value);
          }
       }
