	public class IsoDateTimeOffsetConverter : IsoDateTimeConverter
	{
		public override bool CanConvert(Type objectType)
		{
            return objectType == typeof(DateTimeOffset) || objectType == typeof(DateTimeOffset?);
		}
	}
