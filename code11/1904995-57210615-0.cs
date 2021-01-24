    public class SByteConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(sbyte);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Integer)
            {
                // Integer values come in as longs from the reader.
                long val = (long)reader.Value;
                // If the value fits in 8 bits, convert it to a signed byte.
                if (val >= -128 && val <= 255)
                {
                    return unchecked((sbyte)val);
                }
                // We got a value that can't fit in an sbyte.
                throw new JsonSerializationException("Value was out of range for an sbyte: " + val);
            }
            // We got something we didn't expect, like a string or object.
            throw new JsonSerializationException("Unexpected token type: " + reader.TokenType);
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            // Write sbyte values out in the same format we read them.
            // Note this is technically invalid JSON per the spec.
            writer.WriteRawValue("0x" + ((sbyte)value).ToString("X2"));
        }
    }
