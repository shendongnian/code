    public class CustomFormattingMatrixConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(int[,]);
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            int[,] array = (int[,])value;
            writer.WriteStartArray();
            for (int i = 0, bound0 = array.GetUpperBound(0); i < bound0; i++)
            {
                writer.WriteStartArray();
                writer.Formatting = Formatting.None;
                for (int j = 0, bound1 = array.GetUpperBound(1); j < bound1; j++)
                {
                    writer.WriteValue(array[i, j]);
                }
                writer.WriteEndArray();
                writer.Formatting = Formatting.Indented;
            }
            writer.WriteEndArray();
        }
        public override bool CanRead
        {
            get { return false; }
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
