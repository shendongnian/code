	using static Utility;
	internal class TestUtility
	{
		public static void Tests()
		{
			Repeat(5,
				   () => Console.WriteLine("Hello."));
		}
	}
