    public class LocalDateTimeConverter : JsonConverter
    {
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.Value == null)
            {
                return null;
            }  
            
            var date = DateTime.Parse(reader.Value.ToString(), CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal);
            return TimeZoneInfo.ConvertTimeFromUtc(date, TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time"));
        }
        public override bool CanConvert(Type objectType)
        {
            return true; 
        }
        public override bool CanWrite
        {
            get { return true; }
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }
    } 
