    public class EnumerableByteConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            var result = typeof(IEnumerable<byte>).IsAssignableFrom(objectType);
            return result;
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value == null)
            {
                writer.WriteValue(value);
            }
            else
            {
                byte[] bytes = ((IEnumerable<byte>)value).ToArray();
                int[] ints = Array.ConvertAll(bytes, c => (int)c);
                writer.WriteStartArray();
                foreach (int number in ints)
                {
                    writer.WriteValue(number);
                }
                writer.WriteEndArray();
            }
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            List<int> ints = null;
            if (reader.TokenType == JsonToken.Null)
                return default;
            while (reader.TokenType != JsonToken.EndArray)
            {
                if (reader.TokenType == JsonToken.StartArray)
                {
                    ints = new List<int>();
                    reader.Read();
                }
                else if(reader.TokenType == JsonToken.Integer)
                {
                    ints.Add(Convert.ToInt32(reader.Value));
                    reader.Read();
                }
                else
                {
                    throw new InvalidOperationException();
                }
            }
            if (ints == null)
                return default;
            else
            {
                byte[] bytes = Array.ConvertAll(ints.ToArray(), x => (byte)x);
                if (objectType == typeof(byte[]))
                {
                    return bytes;
                }
                var result = new List<byte>(bytes);
                return result;
            }
        }
    }
