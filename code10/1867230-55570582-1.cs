	using System;
	using System.Threading.Tasks;
	public class Program
	{
		public static async Task Main()
		{
			try
			{
				await PassThrough(Test);   
                // Note that we are now passing in a function delegate for Test,
                // equivalent to () => Test(), not its result.
			} 
			catch (Exception) 
			{
				Console.WriteLine("caught at invocation");
			}
			Console.ReadLine();
		}
		public static async Task PassThrough(Func<Task<bool>> test)
		{
			try
			{
				var task = test();   // exception thrown here
				var result = await task.ConfigureAwait(false);
				// still need to do something with result here...
			}
			catch
			{
				Console.WriteLine("caught in PassThrough");
			}
		}
		/// external code!
		public static Task<bool> Test()
		{
			throw new Exception("something bad");
			// do other async stuff here
			// ...
			return Task.FromResult(true);
		}
	}
