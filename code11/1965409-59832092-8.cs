    /// <summary>
    /// Apply this converter to a property to force the property to be serialized with default options.  
    /// This converter can ONLY be applied to a property; setting it in options or on a type may cause a stack overflow exception!
    /// </summary>
    /// <typeparam name="T">the property's declared return type</typeparam>
	public class SerializePropertyAsDefaultConverter<T> : JsonConverter<T>
	{
		public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			return JsonSerializer.Deserialize<T>(ref reader); // Ignore the incoming options!
		}
		public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
		{
			JsonSerializer.Serialize(writer, value); // Ignore the incoming options!
		} 
	}
