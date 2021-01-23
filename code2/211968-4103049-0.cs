		static void Main(string[] args)
		{
			PropertyInfo intHasValue = typeof (int?).GetProperty("HasValue");
			PropertyInfo boolHasValue = ChangeGenericType(intHasValue, typeof (bool));
		}
		public static PropertyInfo ChangeGenericType(PropertyInfo property, Type targetType)
		{
			Type constructed = property.DeclaringType;
			Type generic = constructed.GetGenericTypeDefinition();
			Type targetConstructed = generic.MakeGenericType(new[] {targetType});
			return targetConstructed.GetProperty(property.Name);
		}
