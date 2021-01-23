    public class DictionaryWithSpecialEnumKeyConverter : JsonConverter
    {
        public override bool CanWrite
        {
            get { return false; }
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotSupportedException();
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;
            var valueType = objectType.GetGenericArguments()[1];
            var intermediateDictionaryType = typeof(Dictionary<,>).MakeGenericType(typeof(string), valueType);
            var intermediateDictionary = (IDictionary)Activator.CreateInstance(intermediateDictionaryType);
            serializer.Populate(reader, intermediateDictionary);
            var finalDictionary = (IDictionary)Activator.CreateInstance(objectType);
            foreach (DictionaryEntry pair in intermediateDictionary)
                finalDictionary.Add(Enum.Parse(MyEnum, "Code" + pair.Key, false), pair.Value);
            return finalDictionary;
        }
        public override bool CanConvert(Type objectType)
        {
            return objectType.IsA(typeof(IDictionary<,>)) &&
                   objectType.GetGenericArguments()[0].IsA<MyEnum>();
        }
    }
