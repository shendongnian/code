    public static class BooleanNullableExtensions 
	{
		public static bool IsTrue(this Nullable<bool> value)
		{
			return value.HasValue && value.Value;
		}
	}
