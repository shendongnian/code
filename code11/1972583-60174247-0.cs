    public static IEnumerable<Type> GetReferencedTypes(Type type)
    {
    	if (type.IsArray)
    		return new List<Type> { type, type.GetElementType() };
    	if (type.IsGenericType)
    		return type.GetGenericArguments().SelectMany(GetReferencedTypes)
    			.Union(new List<Type>{type});
    	return new List<Type>{ type };
    }
