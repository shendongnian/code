	public sealed class ByteConverter : JsonConverter<byte[]>
    {
		[ThreadStatic]
		static bool disabled;
		// Disables the converter in a thread-safe manner.
		bool Disabled { get { return disabled; } set { disabled = value; } }
		public override bool CanRead { get { return !Disabled; } }
        public override byte[] ReadJson(JsonReader reader, Type objectType, byte[] existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            switch (reader.MoveToContentAndAssert().TokenType) // Skip past comments
            {
                case JsonToken.Null:
                    return null;
                case JsonToken.StartArray:
                    // Your custom logic here, e.g.:
                    return serializer.Deserialize<List<byte>>(reader).ToArray();
                default:
					using (new PushValue<bool>(true, () => Disabled, val => Disabled = val))
						return serializer.Deserialize<byte []>(reader);
            }
        }
        // Remainder omitted
		public override bool CanWrite => false;
		public override void WriteJson(JsonWriter writer, byte[] value, JsonSerializer serializer) => throw new NotImplementedException();
    }
	public struct PushValue<T> : IDisposable
	{
		Action<T> setValue;
		T oldValue;
		public PushValue(T value, Func<T> getValue, Action<T> setValue)
		{
			if (getValue == null || setValue == null)
				throw new ArgumentNullException();
			this.setValue = setValue;
			this.oldValue = getValue();
			setValue(value);
		}
		// By using a disposable struct we avoid the overhead of allocating and freeing an instance of a finalizable class.
		public void Dispose()
		{
			if (setValue != null)
				setValue(oldValue);
		}
	}
    public static partial class JsonExtensions
    {
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
