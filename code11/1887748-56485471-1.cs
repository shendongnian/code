    public class LogLevelConverter : JsonConverter<LogLevel>
	{
        public override LogLevel ReadJson(JsonReader reader, Type objectType, LogLevel existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
			switch (reader.MoveToContentAndAssert().TokenType)
			{
				case JsonToken.Null:
					return null;
				case JsonToken.String:
					return LogLevel.FromString((string)reader.Value);
				default:
					throw new JsonSerializationException(string.Format("Unknown token {0}", reader.TokenType));
			}
        }
        public override void WriteJson(JsonWriter writer, LogLevel value, JsonSerializer serializer)
        {
			var logLevel = (LogLevel)value;
			writer.WriteValue(logLevel.Name);
        }
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
