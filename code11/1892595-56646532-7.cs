	public class FooAlgorithm : IAlgorithm
	{
		public string Name => "Foo";
		
		public void Execute()
		{
			Console.WriteLine("Fooing the foo");
		}
	}
	
	public class BarAlgorithm : IAlgorithm
	{
		public string Name => "Bar";
		
		public void Execute()
		{
			Console.WriteLine("Barring the bar");
		}
	}
	
