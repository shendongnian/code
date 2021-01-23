	public static class ExtensionMethods
	{
		public static void Load<T>(this T target, T source)
		{
			foreach (var property in typeof(T).GetProperties())
			{
				if (property.CanWrite)
				{
					property.SetValue(target, property.GetValue(source, null), null);
				}
			}
		}
	}
