    public class OnlyBoolean : JsonConverter
    {
         readonly JsonSerializer defaultSerializer = new JsonSerializer();
         public override bool CanConvert(Type objectType)
         {
             return objectType.GetType() == typeof(bool);
         }
         public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
         {
             switch (reader.TokenType)
             {
                 case JsonToken.Boolean:
                 {
                     return defaultSerializer.Deserialize(reader, objectType);
                 }
                 case JsonToken.String:
                 {
                     if (reader.Value?.ToString() == "true" || reader.Value?.ToString() == "false")
                          return defaultSerializer.Deserialize(reader, objectType);
                     else
                          throw new JsonSerializationException(string.Format("Token \"{0}\" of type {1} is not a boolean type", reader.Value, reader.TokenType));
                }
                case JsonToken.Integer:
                {
                    if (Convert.ToInt32(reader.Value) == 1 || Convert.ToInt32(reader.Value) == 0)
                        return defaultSerializer.Deserialize(reader, objectType);
                    else
                        throw new JsonSerializationException(string.Format("Token \"{0}\" of type {1} is not a boolean type", reader.Value, reader.TokenType));
                }
           default:
                    throw new JsonSerializationException(string.Format("Value\"{0}\" of type {1} is not a boolean type", reader.Value, reader.TokenType));
         }
    }
    public override bool CanWrite { get { return false; } }
    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
          throw new NotImplementedException();
    }
