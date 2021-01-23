	public static class TypeExtensions
	{
		public static IEnumerable<T> EnumerateConstantFields<T>(this Type type)
		{
			return type.GetFields().Where(f => f.IsLiteral).Select(f => f.GetValue(null)).OfType<T>();
		}
	}
