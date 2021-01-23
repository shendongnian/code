	bool ContainsGenericParameter(Type fieldType)
	{
		return fieldType.IsGenericParameter ||
			fieldType.GetGenericArguments().Any(t => ContainsGenericParameter(t));
	}
