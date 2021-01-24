	public class IsoDateTimeOffsetConverter : IsoDateTimeConverter
	{
		public override bool CanConvert(Type objectType)
		{
            return objectType == typeof(DateTimeOffset) || objectType == typeof(DateTimeOffset?);
		}
		
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			var dateTimeOffset = (DateTimeOffset)value;
			if (dateTimeOffset.Offset == TimeSpan.Zero)
			{
				// If there is no offset, serialize as a DateTime
				base.WriteJson(writer, dateTimeOffset.UtcDateTime, serializer);
			}
			else
			{
				base.WriteJson(writer, value, serializer);
			}
		}		
	}
