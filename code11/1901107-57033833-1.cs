	public class MyCustomContractResolver : DefaultContractResolver
	{
		public MyCustomContractResolver() { NamingStrategy = new CamelCaseNamingStrategy(); }
		static ObjectConstructor<Object> GetParameterizedConstructor(JsonObjectContract contract)
		{
			if (contract.OverrideCreator != null)
				return contract.OverrideCreator;
			
			// Here we assume that JsonSerializerSettings.ConstructorHandling == ConstructorHandling.Default
			// If you would prefer AllowNonPublicDefaultConstructor then you need to remove the check on contract.DefaultCreatorNonPublic
			if (contract.CreatorParameters.Count > 0 && (contract.DefaultCreator == null || contract.DefaultCreatorNonPublic))
			{
				// OK, Json.NET has a parameterized constructor stashed away in JsonObjectContract.ParameterizedCreator
				// https://github.com/JamesNK/Newtonsoft.Json/blob/master/Src/Newtonsoft.Json/Serialization/JsonObjectContract.cs#L100
				// But, annoyingly, this value is internal so we cannot get it!
				// But because CreatorParameters.Count > 0 and OverrideCreator == null we can infer that such a constructor exists, and so call it using Activator.CreateInstance
				
				return (args) => Activator.CreateInstance(contract.CreatedType, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance, null, args, CultureInfo.InvariantCulture);
			}
			
			return null;
		}
		static ObjectConstructor<Object> CustomizeConstructor(JsonObjectContract contract, ObjectConstructor<Object> constructor)
		{
			if (constructor == null)
				return null;
			return (args) =>
			{
				// Add here your customization logic.
				// You can match creator parameters to properties property name if needed.
				foreach (var pair in args.Zip(contract.CreatorParameters, (a, p) => new { Value = a, Parameter = p }))
				{
					Console.WriteLine("Argument {0}: Value {1}", pair.Parameter.PropertyName, pair.Value);
				}
				return constructor(args);
			};
		}
        protected override JsonObjectContract CreateObjectContract(Type objectType)
        {
            var contract = base.CreateObjectContract(objectType);
			
			contract.OverrideCreator = CustomizeConstructor(contract, GetParameterizedConstructor(contract));
			
			return contract;
        }
		
		protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
		{
			var jsonProperties = base.CreateProperties(type, memberSerialization);
			foreach (var jsonProperty in jsonProperties)
			{
				var defaultValueProvider = jsonProperty.ValueProvider;
				jsonProperty.ValueProvider = new MyValueProvider(defaultValueProvider);
			}
			return jsonProperties;
		}
	}
