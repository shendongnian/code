	class TestDelegate
	{
			public static void Test()
			{
					Console.WriteLine("In Test");
			}
			public static void Main()
			{
					TestDelegate testDelegate = new TestDelegate(Test);
					testDelegate();
			}
	}
