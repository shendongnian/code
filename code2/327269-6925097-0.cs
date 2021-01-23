	public static class DynamicHelper
	{
		public static TResult As<TResult>(dynamic obj) where TResult : class
		{
			if (obj == null)
				return null;
			try
			{
				return (TResult)obj;
			}
			catch (Exception)
			{
				return null;
			}
		}
	}
