    yourValidatorAssembly.DefinedTypes
        .Where(x => x.GetHierachicalTypes().Any(y => y.IsGenericType && y.GetGenericTypeDefinition() == typeof(AbstractValidator<>)))
    public static class TypeExtensions
    {
    	public static IEnumerable<Type> GetHierachicalTypes(this Type type)
    	{
    		while (type != null)
    		{
    			yield return type;
    			type = type.BaseType;
    		}
    	}
    }
