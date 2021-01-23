	public static bool PropertyReadOnlyAttributeValue(PropertyInfo property)
	{
		ReadonlyAttribute attrib = Attribute.GetCustomAttribute(property, typeof(ReadOnlyAttribute));
		return attrib != null && attrib.IsReadOnly;
	}
	public static bool PropertyReadOnlyAttributeValue(Type type, string propertyName)
	{
		return PropertyReadOnlyAttributeValue(type.GetProperty(propertyName));
	}
	public static bool PropertyReadOnlyAttributeValue(object instance, string propertyName)
	{
		if (instance != null)
		{
			Type type = instance.GetType();
			return PropertyReadOnlyAttributeValue(type, propertyName);
		}
		return false;
	}
