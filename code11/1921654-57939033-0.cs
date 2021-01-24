	using System;
	using System.Threading.Tasks;
	public class Program
	{
		public static void Main()
		{
			var method = typeof(MyEffects).GetMethod("Test");
			var obj = new MyEffects();
			var del = Delegate.CreateDelegate(typeof(Func<object, IDispatcher, Task>), obj, method);
			Console.WriteLine(del);
		}
	}
	public class MyEffects
	{
	  public Task Test(object action, IDispatcher dispatcher)
	  {
		return Task.CompletedTask;
	  }
	}
	public interface IDispatcher {} 
