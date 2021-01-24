	public static partial class JsonExtensions
	{
		public static T ToObject<T>(this JsonElement element, JsonSerializerOptions options = null)
		{
			var bufferWriter = new ArrayBufferWriter<byte>();
			using (var writer = new Utf8JsonWriter(bufferWriter))
				element.WriteTo(writer);
			return JsonSerializer.Deserialize<T>(bufferWriter.WrittenSpan, options);
		}
		public static T ToObject<T>(this JsonDocument document, JsonSerializerOptions options = null)
		{
			if (document == null)
				throw new ArgumentNullException(nameof(document));
			return document.RootElement.ToObject<T>(options);
		}		
	}
