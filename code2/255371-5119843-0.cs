	public static class DoubleInExtension
	{
		public static bool IsIn(this double x, double a, double b)
		{
			return x >= a && x <= b;
		}
	}
