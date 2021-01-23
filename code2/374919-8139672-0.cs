	public static class ReflectionExtensions
	{
		public static T GetPrivateFieldValue<T>(this object instance, string fieldName)
		{
			var field = instance.GetType().GetField(fieldName, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
			if (field != null)
			{
				return (T) field.GetValue(instance);
			}
			throw new ArgumentException("The field specified could not be located.", "fieldName");
		}
		public static void SetReadonlyProperty(this object instance, string propertyName, object value)
		{
			instance.GetType().GetProperty(propertyName).SetValue(instance, value, null);
		}
		public static void SetStaticReadonlyProperty(this Type type, string propertyName, object value)
		{
			type.GetProperty(propertyName).GetSetMethod(true).Invoke(null, new[] { value });
		}
	}
