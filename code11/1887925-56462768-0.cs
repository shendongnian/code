	public class Bar
	{
	}
	public class Foo
	{
	}
	public class Service
	{
		public Bar Send(Bar objToSend)
		{
			Console.WriteLine("Send Bar");
			return objToSend;
		}
		
		public Foo Send(Foo objToSend)
		{
			Console.WriteLine("Send Foo");
			return objToSend;
		}
	}
