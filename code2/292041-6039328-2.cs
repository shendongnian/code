    class Program
	{
		static void Main(string[] args)
		{
			Foo foo = new Foo();
			try
			{
				using (Bar bar = foo.CreateBar())
				{
					throw new ApplicationException("Something wrong inside the using.");
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
			return new Bar();
			// throw new ApplicationException("Something went wrong.");
		}
	}
	public class Bar : IDisposable
	{
		public void Dispose()
		{
		}
	}
