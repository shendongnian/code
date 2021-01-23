	static class enum_info_cache<T> where T : struct
	{
		static _enum_info_cache()
		{
			values = (ulong[])typeof(System.Enum)
				.GetMethod("InternalGetValues", BindingFlags.Static | BindingFlags.NonPublic)
				.Invoke(null, new[] { typeof(T) });
			names = (String[])typeof(System.Enum)
				.GetMethod("InternalGetNames", BindingFlags.Static | BindingFlags.NonPublic)
				.Invoke(null, new[] { typeof(T) });
		}
		public static readonly ulong[] values;
		public static readonly String[] names;
	};
