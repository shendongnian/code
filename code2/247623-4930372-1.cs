	public static class ExtensionMethods
	{
		public static void Load<T>(this T target, T source)
		{
			foreach (PropertyInfo property in typeof(T).GetProperties())
			{
				if (property.CanWrite && property.CanRead)
				{
					if (property.PropertyType.IsPrimitive || property.PropertyType.IsValueType || property.PropertyType == typeof(String))
					{
						property.SetValue(target, property.GetValue(source, null), null);
					}
					else
					{
						property.GetValue(target, null).Load(property.GetValue(source, null));
					}
				}
			}
		}
	}
