	public class MyGeneric<T>
	{
		static MyGeneric()
		{
			var def = default(T); 
			if (def is ValueType && Nullable.GetUnderlyingType(typeof(T)) == null)
			{
				throw new InvalidOperationException(
					string.Format("Cannot instantiate with non-nullable type: {0}",
						typeof(T)));
			}
		}
	}
