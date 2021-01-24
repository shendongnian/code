    public class CustomFormattingArrayConverter : JsonConverter
    {
        private int ItemsPerLine { get; set; }
        public CustomFormattingArrayConverter(int itemsPerLine)
        {
            if (itemsPerLine < 1) throw new ArgumentException("itemsPerLine must be 1 or more");
            ItemsPerLine = itemsPerLine;
        }
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(List<object>);
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            List<object> list = (List<object>)value;
            writer.WriteStartArray();
            for (int i = 0; i < list.Count; i++)
            {
                if (i % ItemsPerLine == 0) writer.Formatting = Formatting.Indented;
                serializer.Serialize(writer, list[i]);
                if (i % ItemsPerLine == 0) writer.Formatting = Formatting.None;
            }
            writer.Formatting = Formatting.Indented;
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
