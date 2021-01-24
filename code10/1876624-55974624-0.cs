	static class Calc<T>
	{
		public static T Add(T a, T b)
		{
			if (typeof(T) == typeof(int))
			{
				return (T)(object)((int)(object)a + (int)(object)b);
			}
			
			if (typeof(T) == typeof(uint))
			{
				return (T)(object)((uint)(object)a + (uint)(object)b);
			}
			
			throw new ArgumentOutOfRangeException($"Type {typeof(T).Name} is not supported.");
		}    
	}
