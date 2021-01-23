	public class Foo
	{
		public void PrintAssembly()
		{
			Console.WriteLine(this.GetType().Assembly.GetName());
			Console.WriteLine(Assembly.GetExecutingAssembly().GetName());
		}
	}
