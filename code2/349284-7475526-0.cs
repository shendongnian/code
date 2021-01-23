	public class Test
	{
		public void Print(int number)
		{
			Console.WriteLine("Number: " + number);
		}
	
		public void Print(Options option)
		{
			Console.WriteLine("Option: " + option);
		}
	}
	public enum Options
	{
		A = 0,
		B = 1
	}
