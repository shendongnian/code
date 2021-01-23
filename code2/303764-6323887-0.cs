	public static void CopyProperties(object a, object b)
	{
		if (a.GetType() != b.GetType())
			throw new ArgumentException("Types of object a and b should be the same", "b")
		foreach (PropertyInfo property in a.GetType().GetProperties())
		{
			if (!property.CanRead || !property.CanWrite || (property.GetIndexParameters().Length > 0))
				continue;
			
			property.SetValue(b, property.GetValue(a, null), null);
		}
	}
