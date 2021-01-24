	public static partial class JsonExtensions
	{
		static readonly IContractResolver defaultResolver = new JsonSerializer().ContractResolver;
		
		public static T GetJsonPropertyValue<T>(object obj, string propertyName, IContractResolver resolver = null)
		{
			resolver = resolver ?? defaultResolver;
			var contract = resolver.ResolveContract(obj.GetType());
			if (contract is JsonObjectContract objectContract)
			{
				var property = objectContract.Properties.GetClosestMatchProperty(propertyName);
				if (property == null)
					throw new JsonException(string.Format("Unknown property {0}", propertyName));
				return (T)property.ValueProvider.GetValue(obj);
			}
			throw new JsonException(string.Format("Invalid contract {0}", contract));
		}
	}
