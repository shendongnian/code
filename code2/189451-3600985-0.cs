	public static class SharedMethods
	{
		public static void SharedMethod1()
		{
			ClassA.SharedMethod1();
		}
		public static string GetName()
		{
			return NameProvider.GetName();
		}
		public static int GetCount()
		{
			return CountClass.GetCount();
		}
	}
