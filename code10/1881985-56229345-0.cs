    public class CustomDictionaryConverter : JsonConverter
    {
        // Adapted from CustomDictionaryConverter from this answer https://stackoverflow.com/a/40265708
        // To https://stackoverflow.com/questions/40257262/serializing-dictionarystring-string-to-array-of-name-value
        // By Brian Rogers https://stackoverflow.com/users/10263/brian-rogers
        sealed class InconvertibleDictionary : Dictionary<object, object>
        {
            public InconvertibleDictionary(DictionaryEntry entry)
                : base(1)
            {
                this[entry.Key] = entry.Value;
            }
        }
        public override bool CanConvert(Type objectType)
        {
            return typeof(IDictionary).IsAssignableFrom(objectType) && objectType != typeof(InconvertibleDictionary);
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            // Lazy evaluation of the enumerable prevents materialization of the entire collection of dictionaries at once.
            serializer.Serialize(writer,  Entries(((IDictionary)value)).Select(p => new InconvertibleDictionary(p)));
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.MoveToContentAndAssert().TokenType == JsonToken.Null)
                return null;
            var dictionary = existingValue ?? serializer.ContractResolver.ResolveContract(objectType).DefaultCreator();
            switch (reader.TokenType)
            {
                case JsonToken.StartObject:
                    serializer.Populate(reader, dictionary);
                    return dictionary;
                case JsonToken.StartArray:
                    {
                        while (true)
                        {
                            switch (reader.ReadToContentAndAssert().TokenType)
                            {
                                case JsonToken.EndArray:
                                    return dictionary;
                                case JsonToken.StartObject:
                                    serializer.Populate(reader, dictionary);
                                    break;
                                default:
                                    throw new JsonSerializationException(string.Format("Unexpected token {0}", reader.TokenType));
                            }
                        }
                    }
                default:
                    throw new JsonSerializationException(string.Format("Unexpected token {0}", reader.TokenType));
            }
        }
        static IEnumerable<DictionaryEntry> Entries(IDictionary dict)
        {
            foreach (DictionaryEntry entry in dict)
                yield return entry;
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
