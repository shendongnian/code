    public static class NullExtension
	{
		public static T OrNew<T>(this T thing)
			where T: class, new()
		{
			return thing ?? new T();
		}
	}
