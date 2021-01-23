	public static class ExtensionMethods
	{
		public static void Load<T>(this T target, Type type, T source, bool deep)
		{
			foreach (PropertyInfo property in type.GetProperties())
			{
				if (property.CanWrite && property.CanRead)
				{
					if (!deep || property.PropertyType.IsPrimitive || property.PropertyType == typeof(String))
					{
						property.SetValue(target, property.GetValue(source, null), null);
					}
					else
					{
						object targetPropertyReference = property.GetValue(target, null);
						targetPropertyReference.Load(targetPropertyReference.GetType(), property.GetValue(source, null), deep);
					}
				}
			}
		}
	}
