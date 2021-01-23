	/// <summary>
	/// To address issues with automatic Int64 deserialization -- see http://stackoverflow.com/a/9444519/1037948
	/// </summary>
	public class JsonInt32Converter : JsonConverter
	{
		#region Overrides of JsonConverter
		/// <summary>
		/// Only want to deserialize
		/// </summary>
		public override bool CanWrite { get { return false; } }
		/// <summary>
		/// Placeholder for inheritance -- not called because <see cref="CanWrite"/> returns false
		/// </summary>
		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			// since CanWrite returns false, we don't need to implement this
			throw new NotImplementedException();
		}
		/// <summary>
		/// Reads the JSON representation of the object.
		/// </summary>
		/// <param name="reader">The <see cref="T:Newtonsoft.Json.JsonReader"/> to read from.</param><param name="objectType">Type of the object.</param><param name="existingValue">The existing value of object being read.</param><param name="serializer">The calling serializer.</param>
		/// <returns>
		/// The object value.
		/// </returns>
		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			return (reader.TokenType == JsonToken.Integer)
				? Convert.ToInt32(reader.Value)		// convert to Int32 instead of Int64
				: serializer.Deserialize(reader);	// default to regular deserialization
		}
		/// <summary>
		/// Determines whether this instance can convert the specified object type.
		/// </summary>
		/// <param name="objectType">Type of the object.</param>
		/// <returns>
		/// <c>true</c> if this instance can convert the specified object type; otherwise, <c>false</c>.
		/// </returns>
		public override bool CanConvert(Type objectType)
		{
			return objectType == typeof(Int32) ||
					objectType == typeof(Int64) ||
					objectType == typeof(int) ||
					// need this last one in case we "weren't given" the type
					// and this will be accounted for by `ReadJson` checking tokentype
					objectType == typeof(object)
				;
		}
		#endregion
	}
