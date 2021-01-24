    public sealed class UTCDateTimeConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(DateTime?);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.Value is null) return null;
            try
            {
                return new DateTime((long)reader.Value);
            }
            catch
            {
                if (DateTime.TryParse(reader.Value.ToString(), out DateTime d))
                    return d;
                else
                    return null;
            }
        }
    
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var val = ((DateTime)value).Ticks;
            writer.WriteValue(val);
        }
    }
