	static class Obj
	{
		public static T OrDefault<T>(Func<T> func, T def)
		{
			T result;
			try
			{
				result = func();
			}
			catch (NullReferenceException)
			{
				result = def;
			}
			return result;
		}
	}
