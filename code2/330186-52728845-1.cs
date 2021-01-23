        public class NameValueJsonConverter<TNameValueCollection> : JsonConverter
            where TNameValueCollection : NameValueCollection, new()
        {
            public override bool CanConvert(Type objectType)
            {
                return typeof(TNameValueCollection).IsAssignableFrom(objectType);
            }
            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                if (reader.SkipComments().TokenType == JsonToken.Null)
                    return null;
                // Reuse the existing NameValueCollection if present
                var collection = (TNameValueCollection)existingValue ?? new TNameValueCollection();
                var dictionaryWrapper = collection.ToDictionaryAdapter();
                serializer.Populate(reader, dictionaryWrapper);
                return collection;
            }
            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                var collection = (TNameValueCollection)value;
                var dictionaryWrapper = new NameValueCollectionDictionaryAdapter<TNameValueCollection>(collection);
                serializer.Serialize(writer, dictionaryWrapper);
            }
        }
        public static partial class JsonExtensions
        {
            public static JsonReader SkipComments(this JsonReader reader)
            {
                while (reader.TokenType == JsonToken.Comment && reader.Read())
                    ;
                return reader;
            }
        }
    Which could be used e.g. as follows:
        string json = JsonConvert.SerializeObject(Data, Formatting.Indented, new NameValueJsonConverter<NameValueCollection>());
