    class Class1
	{
		public int a;
		public static void testWithoutTC()
		{
			Class1 obj = null;
			obj.a = 1;
		}
		public static void testWithTC1()
		{
			try
			{
				Class1 obj = null;
				obj.a = 1;
			}
			catch
			{
				throw;
			}
		}
		public static void testWithTC2()
		{
			try
			{
				Class1 obj = null;
				obj.a = 1;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
