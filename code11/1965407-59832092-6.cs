	public class OptOutJsonConverterFactory : JsonConverterFactoryDecorator
	{
		readonly HashSet<Type> optOutTypes;
		
		public OptOutJsonConverterFactory(JsonConverterFactory innerFactory, params Type [] optOutTypes) : base(innerFactory) => this.optOutTypes = optOutTypes.ToHashSet();
		public override bool CanConvert(Type typeToConvert) => base.CanConvert(typeToConvert) && !optOutTypes.Contains(typeToConvert);
	}
	
	public class JsonConverterFactoryDecorator : JsonConverterFactory
	{
		readonly JsonConverterFactory innerFactory;
	
		public JsonConverterFactoryDecorator(JsonConverterFactory innerFactory)
		{
			if (innerFactory == null)
				throw new ArgumentNullException(nameof(innerFactory));
			this.innerFactory = innerFactory;
		}
		public override bool CanConvert(Type typeToConvert) => innerFactory.CanConvert(typeToConvert);
		
		public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options) => innerFactory.CreateConverter(typeToConvert, options);
	}
