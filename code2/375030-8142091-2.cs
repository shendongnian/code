    class Program
	{
		static void Main()
		{
			new Program().DummyFn();
		}
		public class Simple : System.Attribute
		{
			public Simple()
			{
				System.Console.WriteLine("Simple ct");
			}
		}
		[Simple]
		public void DummyFn()
		{
			System.Console.WriteLine("Dummy fn!");
		}
	}
