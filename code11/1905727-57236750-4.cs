    public class PointConverter : JsonConverter
    {
        readonly NumberFormatInfo numberFormatInfo = new NumberFormatInfo
        {
            NumberDecimalSeparator = ",",
            NumberGroupSeparator = ".",
        };
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Point) || objectType == typeof(Point?);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            switch (reader.MoveToContentAndAssert().TokenType)
            {
                case JsonToken.Null:
                    return null;
                case JsonToken.String:
                    {
                        var s = (string)reader.Value;
                        var values = s.Split(';');
                        if (values.Length != 2)
                            throw new JsonSerializationException(string.Format("Invalid Point format {0}", s));
                        try
                        {
                            return new Point(double.Parse(values[0], numberFormatInfo), double.Parse(values[1], numberFormatInfo));
                        }
                        catch (Exception ex)
                        {
                            throw new JsonSerializationException(string.Format("Invalid Point format {0}", s), ex);
                        }
                    }
                default:
                    throw new JsonSerializationException(string.Format("Unexpected token {0}", reader.TokenType));
            }
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue(((Point)value).ToString(numberFormatInfo));
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
