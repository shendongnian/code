	public static class JsonExtensions
	{
		public static T DeserializeAnonymousType<T>(TextReader textReader, T anonymousTypeObject, JsonSerializerSettings settings = null)
		{
			return (T)JsonSerializer.CreateDefault(settings).Deserialize(textReader, typeof(T));
		}
	}
