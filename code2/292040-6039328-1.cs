    class Program
	{
		static void Main(string[] args)
		{
			Foo foo = new Foo();
			try
			{
				using (Bar bar = foo.CreateBar())
				{
					
				}
			}
			catch(Exception exception)
			{
				Console.WriteLine(exception.Message);
			}
		}
	}
	public class Foo
	{
		public Bar CreateBar()
		{
			throw new ApplicationException("Something went wrong.");
		}
	}
	public class Bar : IDisposable
	{
		public void Dispose()
		{
		}
	}
