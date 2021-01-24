    public class CaseConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return true;
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value.GetType() == typeof(string) || value.GetType() ==  typeof(int))
            {
                writer.WriteValue(value.ToString().ToLower());
            }
            else
            {
                var enumerable = value as System.Collections.IEnumerable;
                if (enumerable != null)
                {
                    writer.WriteStartArray();
                    foreach (var item in enumerable)
                    {
                        serializer.Serialize(writer, item);
                    }
                    writer.WriteEndArray();
                }
                else
                {
                    writer.WriteStartObject();
                    PropertyInfo[] properties = value.GetType().GetProperties();
                    foreach (PropertyInfo pi in properties)
                    {
                        writer.WritePropertyName(pi.Name.ToLower());
                        serializer.Serialize(writer, pi.GetValue(value));
                    }
                    writer.WriteEndObject();
                }
            }
        }
