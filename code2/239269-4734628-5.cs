    public static class BoleanNullableExtensions 
	{
		public static bool IsTrue(this Nullable<bool> value)
		{
			return value.HasValue && value.Value;
		}
	}
