    public class BaseDerivedTypeConverter : DefaultContractResolver
	{
        // You need this to protect yourself against circular dependencies
		protected override JsonConverter ResolveContractConverter(Type objectType)
		{
			return typeof(Base).IsAssignableFrom(objectType) && !objectType.IsAbstract
				? null
				: base.ResolveContractConverter(objectType);
		}
	}
	public class DerivedTypeConverter : JsonConverter
	{
		private static readonly JsonSerializerSettings Settings =
			new JsonSerializerSettings()
			{
				ContractResolver = new BaseDerivedTypeConverter()
			};
		public override bool CanConvert(Type objectType) => (objectType == typeof(Base));
		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			JObject jsonObject = JObject.Load(reader);
            // Make checks if jsonObject["$type"].Value<string>() has a supported type
            // You can have a static dictionary or a const array of supported types
            // You can leverage the array or dictionary to get the type you want again
			var type = Type.GetType("Full namespace to the type you want", false); // the false flag means that the method call won't throw an exception on error
			if (type != null)
			{
				return JsonConvert.DeserializeObject(jsonObject.ToString(), type, Settings);
			}
			else
			{
				throw new ValidationException("No valid $type has been specified!");
			}
		}
		public override bool CanWrite => false;
		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) => throw new NotImplementedException();
    }
