	...
	mapper.IsPersistentProperty((memberInfo, declared) => IsPersistentProperty(mapper.ModelInspector, memberInfo, declared, "YourPropertyName"));
	...
	public static bool IsPersistentProperty(IModelInspector modelInspector, MemberInfo member, bool declared, string propertyName)
	{
	    return (declared ||(member is PropertyInfo) && !IsReadOnlyProperty(member)) && !member.Name.Equals(propertyName);
	}
	private static bool IsReadOnlyProperty(MemberInfo subject)
	{
		const BindingFlags defaultBinding = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.DeclaredOnly;
		var property = subject as PropertyInfo;
		if (property == null)
		{
			return false;
		}
		if (CanReadCantWriteInsideType(property) || CanReadCantWriteInBaseType(property))
		{
			return !PropertyToField.DefaultStrategies.Values.Any(s => subject.DeclaringType.GetField(s.GetFieldName(property.Name), defaultBinding) != null) || IsAutoproperty(property);
		}
		return false;
	}
	private static bool IsAutoproperty(PropertyInfo property)
	{
		return property.ReflectedType.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance
																				 | BindingFlags.DeclaredOnly).Any(pi => pi.Name == string.Concat("<", property.Name, ">k__BackingField"));
	}
	private static bool CanReadCantWriteInsideType(PropertyInfo property)
	{
		return !property.CanWrite && property.CanRead && property.DeclaringType == property.ReflectedType;
	}
	private static bool CanReadCantWriteInBaseType(PropertyInfo property)
	{
		if (property.DeclaringType == property.ReflectedType)
		{
			return false;
		}
		var rfprop = property.DeclaringType.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance
																				 | BindingFlags.DeclaredOnly).SingleOrDefault(pi => pi.Name == property.Name);
		return rfprop != null && !rfprop.CanWrite && rfprop.CanRead;
	}
