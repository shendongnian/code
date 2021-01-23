    public class DictionarySerializer<TDictionary, KeySerializer, ValueSerializer> : DictionarySerializerBase<TDictionary>
        where TDictionary : class, IDictionary, new()
        where KeySerializer : IBsonSerializer, new()
        where ValueSerializer : IBsonSerializer, new()
    {
        public DictionarySerializer() : base(DictionaryRepresentation.Document, new KeySerializer(), new ValueSerializer())
        {
        }
        protected override TDictionary CreateInstance()
        {
            return new TDictionary();
        }
    }
    public class EnumStringSerializer<TEnum> : EnumSerializer<TEnum>
        where TEnum : struct
    {
        public EnumStringSerializer() : base(BsonType.String) { }
    }
