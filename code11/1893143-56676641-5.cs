    public class ISerializableJsonConverter<T> : JsonConverter where T : ISerializable
    {
        // Simplified from 
        //  - JsonSerializerInternalReader.CreateISerializable()
        //    https://github.com/JamesNK/Newtonsoft.Json/blob/master/Src/Newtonsoft.Json/Serialization/JsonSerializerInternalReader.cs#L1708
        //  - JsonSerializerInternalWriter.SerializeISerializable()
        //    https://github.com/JamesNK/Newtonsoft.Json/blob/master/Src/Newtonsoft.Json/Serialization/JsonSerializerInternalWriter.cs#L837
        // By James Newton-King http://james.newtonking.com/
        // Not implemented: 
        // PreserveReferencesHandling, TypeNameHandling, ReferenceLoopHandling, NullValueHandling	
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(T);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.MoveToContentAndAssert().TokenType == JsonToken.Null)
                return null;
            if (reader.TokenType != JsonToken.StartObject)
                throw new JsonSerializationException(string.Format("Unexpected token {0}", reader.TokenType));
            SerializationInfo serializationInfo = new SerializationInfo(objectType, new JsonFormatterConverter(serializer));
            while (reader.ReadToContentAndAssert().TokenType != JsonToken.EndObject)
            {
                switch (reader.TokenType)
                {
                    case JsonToken.PropertyName:
                        serializationInfo.AddValue((string)reader.Value, JToken.ReadFrom(reader.ReadToContentAndAssert())); 
                        break;
                    default:
                        throw new JsonSerializationException(string.Format("Unexpected token {0}", reader.TokenType));
                }
            }
            return Activator.CreateInstance(objectType, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance, null, new object[] { serializationInfo, serializer.Context }, serializer.Culture);
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var serializable = (ISerializable)value;
            SerializationInfo serializationInfo = new SerializationInfo(value.GetType(), new FormatterConverter());
            serializable.GetObjectData(serializationInfo, serializer.Context);
            writer.WriteStartObject();
            foreach (SerializationEntry serializationEntry in serializationInfo)
            {
                writer.WritePropertyName(serializationEntry.Name);
                serializer.Serialize(writer, serializationEntry.Value);
            }
            writer.WriteEndObject();
        }
    }
    public static partial class JsonExtensions
    {
        public static JsonReader ReadToContentAndAssert(this JsonReader reader)
        {
            return reader.ReadAndAssert().MoveToContentAndAssert();
        }
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
    internal class JsonFormatterConverter : IFormatterConverter
    {
        //Adapted and simplified from 
        // https://github.com/JamesNK/Newtonsoft.Json/blob/master/Src/Newtonsoft.Json/Serialization/FormatterConverter.cs
        // By James Newton-King http://james.newtonking.com/
        JsonSerializer serializer;
        public JsonFormatterConverter(JsonSerializer serializer)
        {
            this.serializer = serializer;
        }
        private T GetTokenValue<T>(object value)
        {
            JValue v = (JValue)value;
            return (T)System.Convert.ChangeType(v.Value, typeof(T), CultureInfo.InvariantCulture);
        }
        public object Convert(object value, Type type)
        {
            if (!(value is JToken))
            {
                throw new ArgumentException("Value is not a JToken.", "value");
            }
            return ((JToken)value).ToObject(type, serializer);
        }
        public object Convert(object value, TypeCode typeCode)
        {
            if (value is JValue)
            {
                value = ((JValue)value).Value;
            }
            return System.Convert.ChangeType(value, typeCode, CultureInfo.InvariantCulture);
        }
        public bool ToBoolean(object value)
        {
            return GetTokenValue<bool>(value);
        }
        public byte ToByte(object value)
        {
            return GetTokenValue<byte>(value);
        }
        public char ToChar(object value)
        {
            return GetTokenValue<char>(value);
        }
        public DateTime ToDateTime(object value)
        {
            return GetTokenValue<DateTime>(value);
        }
        public decimal ToDecimal(object value)
        {
            return GetTokenValue<decimal>(value);
        }
        public double ToDouble(object value)
        {
            return GetTokenValue<double>(value);
        }
        public short ToInt16(object value)
        {
            return GetTokenValue<short>(value);
        }
        public int ToInt32(object value)
        {
            return GetTokenValue<int>(value);
        }
        public long ToInt64(object value)
        {
            return GetTokenValue<long>(value);
        }
        public sbyte ToSByte(object value)
        {
            return GetTokenValue<sbyte>(value);
        }
        public float ToSingle(object value)
        {
            return GetTokenValue<float>(value);
        }
        public string ToString(object value)
        {
            return GetTokenValue<string>(value);
        }
        public ushort ToUInt16(object value)
        {
            return GetTokenValue<ushort>(value);
        }
        public uint ToUInt32(object value)
        {
            return GetTokenValue<uint>(value);
        }
        public ulong ToUInt64(object value)
        {
            return GetTokenValue<ulong>(value);
        }
    }
