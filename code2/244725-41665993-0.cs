	public static bool RespectsGenericTypeConstraints(this Type type, Type genericParameter)
	{
		if (type == null)
		{
			throw new ArgumentNullException("type");
		}
		if (genericParameter == null)
		{
			throw new ArgumentNullException("genericParameter");
		}
		if (!genericParameter.IsGenericParameter)
		{
			throw new ArgumentException("genericParameter");
		}
		var attributes = genericParameter.GenericParameterAttributes;
		if (attributes != GenericParameterAttributes.None)
		{
			if (attributes.HasFlag(GenericParameterAttributes.NotNullableValueTypeConstraint) &&
				!type.IsValueType) // TODO: Research how nullable types are handled in constraints
			{
				return false;
			}
			if (attributes.HasFlag(GenericParameterAttributes.ReferenceTypeConstraint) &&
				type.IsValueType)
			{
				return false;
			}
			if (attributes.HasFlag(GenericParameterAttributes.DefaultConstructorConstraint) &&
				type.GetConstructor(Type.EmptyTypes) == null)
			{
				return false;
			}
			// TODO: Covariance and contravariance
		}
		foreach (var constraint in genericParameter.GetGenericParameterConstraints())
		{
			if (!constraint.IsAssignableFrom(type))
			{
				return false;
			}
		}
		return true;
	}
