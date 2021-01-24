    public class PositionDictionaryConverter : DictionaryAsValueListConverter<Position>
	{
		protected override string GetKey(Position position) { return position.Ticker; }
	}
	
    public abstract class DictionaryAsValueListConverter<TValue> : JsonConverter
	{
		protected abstract string GetKey(TValue value);
	
        public override bool CanConvert(Type objectType)
        {
            return typeof(Dictionary<string, TValue>).IsAssignableFrom(objectType);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.MoveToContent().TokenType == JsonToken.Null)
                return null;
			var list = serializer.Deserialize<List<TValue>>(reader);
			var dictionary = (IDictionary<string, TValue>)(existingValue ?? serializer.ContractResolver.ResolveContract(objectType).DefaultCreator());
			foreach (var item in list)
				dictionary.Add(GetKey(item), item);
			return dictionary;
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, ((IDictionary<string, TValue>)value).Values);
        }
    }
	public static partial class JsonExtensions
    {
        public static JsonReader MoveToContent(this JsonReader reader)
        {
            if (reader.TokenType == JsonToken.None)
                reader.Read();
            while (reader.TokenType == JsonToken.Comment && reader.Read())
                ;
            return reader;
        }
	}
