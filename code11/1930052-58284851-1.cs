    	public abstract class Page<T> where T: new()
	{
		public static readonly T instance = new T();
		public abstract void GoTo();
	}
	public class Home : Page<Home>
	{
		public override void GoTo()
		{
			Console.WriteLine("goto home");
		}
	}
	public class Login : Page<Login>
	{
		public override void GoTo()
		{
			Console.WriteLine("goto Login");
		}
	}
