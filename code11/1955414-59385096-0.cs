	public class AlarmsConverter : JsonConverter<Alarms>
	{
        public override Alarms ReadJson(JsonReader reader, Type objectType, Alarms existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
			switch (reader.MoveToContentAndAssert().TokenType)
			{
				case JsonToken.Null:
				case JsonToken.Integer:
					return null;
				
				default:
					var alarm = hasExistingValue ? existingValue : (Alarms)serializer.ContractResolver.ResolveContract(objectType).DefaultCreator();
					serializer.Populate(reader, alarm);
					return alarm;
			}
        }
		public override bool CanWrite => false;
        public override void WriteJson(JsonWriter writer, Alarms value, JsonSerializer serializer) => throw new NotImplementedException();
	}
	
    public static partial class JsonExtensions
    {
        public static JsonReader MoveToContentAndAssert(this JsonReader reader)
        {
            if (reader == null)
                throw new ArgumentNullException();
            if (reader.TokenType == JsonToken.None)       // Skip past beginning of stream.
                reader.ReadAndAssert();
            while (reader.TokenType == JsonToken.Comment) // Skip past comments.
                reader.ReadAndAssert();
            return reader;
        }
        public static JsonReader ReadAndAssert(this JsonReader reader)
        {
            if (reader == null)
                throw new ArgumentNullException();
            if (!reader.Read())
                throw new JsonReaderException("Unexpected end of JSON stream.");
            return reader;
        }
    }
