      public class PairConverter : JsonConverter
            {
                public override bool CanConvert(Type objectType)
                {
                    return objectType == typeof(KeyValuePair<string, int>);
                }
    
                public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
                {
                    throw new NotImplementedException();
                }
    
                public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
                {
                    var item = (KeyValuePair<string, int>)value;
                    writer.WriteValue(item.Value);
                    writer.Flush();
                }
            }
