    public static partial class JsonExtensions
    {
        public static string [] PropertyNames(Type type)
		{
			return PropertyNames(defaultResolver, type);
		}
		
		//Taken from this answer https://stackoverflow.com/a/45829514/3744182
		//To https://stackoverflow.com/questions/33616005/get-a-list-of-json-property-names-from-a-class-to-use-in-a-query-string
        public static string [] PropertyNames(this IContractResolver resolver, Type type)
        {
            if (resolver == null || type == null)
                throw new ArgumentNullException();
            var contract = resolver.ResolveContract(type) as JsonObjectContract;
            if (contract == null)
                return new string[0];
            return contract.Properties.Where(p => !p.Ignored).Select(p => p.PropertyName).ToArray();
        }
    }
