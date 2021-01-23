	public class TestBase
	{
		public void Print(int number)
		{
			Console.WriteLine("Number: " + number);
		}
	}
	
	public class Test : TestBase
	{
		public void Print(Options option)
		{
			Console.WriteLine("Option: " + option);
		}
	}
