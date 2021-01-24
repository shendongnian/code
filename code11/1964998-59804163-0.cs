	public static partial class JsonExtensions
	{
		static readonly IContractResolver defaultResolver = JsonSerializer.CreateDefault().ContractResolver;
		
		public static object GetJsonProperty<T>(T obj, string jsonName, bool exact = false, IContractResolver resolver = null)
		{
			if (obj == null)
				throw new ArgumentNullException(nameof(obj));
			resolver = resolver ?? defaultResolver;
			var contract = resolver.ResolveContract(obj.GetType()) as JsonObjectContract;
			if (contract == null)
				throw new ArgumentException(string.Format("{0} is not serialized as a JSON object", obj));
			var property = contract.Properties.GetProperty(jsonName, exact ? StringComparison.Ordinal : StringComparison.OrdinalIgnoreCase);
			if (property == null)
				throw new ArgumentException(string.Format("Property {0} was not found.", obj));
			return property.ValueProvider.GetValue(obj);
		}
	}
