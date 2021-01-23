	public static string Description(this Enum value)
	{
		var type = value.GetType();
		var name = Enum.GetName(type, value);
		if (name != null)
		{
			if (type.GetField(name) != null)
			{
				var attr = Attribute.GetCustomAttribute(type.GetField(name), typeof(DescriptionAttribute)) as DescriptionAttribute;
				return attr != null ? attr.Description : name;
			}
		}
		return null;
	} // end
