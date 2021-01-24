    public class PeriodConverter : JsonConverter<Period>
    {
        public override void WriteJson(JsonWriter writer, Period period, JsonSerializer serializer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName(nameof(Period.Start));
            writer.WriteValue(period.Start);
            writer.WritePropertyName(nameof(Period.End));
            writer.WriteValue(period.End);
            writer.WriteEndObject();
        }
        public override Period ReadJson(JsonReader reader, Type objectType, Period existingValue, bool hasExistingValue,
            JsonSerializer serializer)
        {
            throw new NotSupportedException();
        }
    }
