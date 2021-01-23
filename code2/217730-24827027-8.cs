    using System;
	using System.Threading;
	using System.Threading.Tasks;
	namespace TaskTimeout
	{
		public static class Program
		{
			/// <summary>
			///		Demo of how to wrap any function in a timeout.
			/// </summary>
			private static void Main(string[] args)
			{
				
				// Version without timeout.
				int a = MyFunc();
				Console.Write("Result: {0}\n", a);
				// Version with timeout.
				int b = TimeoutAfter(() => { return MyFunc(); },TimeSpan.FromSeconds(1));
				Console.Write("Result: {0}\n", b);
				// Version with timeout (short version that uses method groups). 
				int c = TimeoutAfter(MyFunc, TimeSpan.FromSeconds(1));
				Console.Write("Result: {0}\n", c);
				// Version that lets you see what happens when a timeout occurs.
				try
				{				
					int d = TimeoutAfter(
						() =>
						{
							Thread.Sleep(TimeSpan.FromSeconds(123));
							return 42;
						},
						TimeSpan.FromSeconds(1));
					Console.Write("Result: {0}\n", d);
				}
				catch (TimeoutException e)
				{
					Console.Write("Exception: {0}\n", e.Message);
				}
				// Version that works on tasks.
				var task = Task.Run(() =>
				{
					Thread.Sleep(TimeSpan.FromSeconds(1));
					return 42;
				});
				// To use async/await, add "await" and remove "GetAwaiter().GetResult()".
				var result = task.TimeoutAfterAsync(TimeSpan.FromSeconds(2)).
                               GetAwaiter().GetResult();
				Console.Write("Result: {0}\n", result);
				Console.Write("[any key to exit]");
				Console.ReadKey();
			}
			public static int MyFunc()
			{
				return 42;
			}
			public static TResult TimeoutAfter<TResult>(
				this Func<TResult> func, TimeSpan timeout)
			{
				var task = Task.Run(func);
				return TimeoutAfterAsync(task, timeout).GetAwaiter().GetResult();
			}
			private static async Task<TResult> TimeoutAfterAsync<TResult>(
				this Task<TResult> task, TimeSpan timeout)
			{
				var result = await Task.WhenAny(task, Task.Delay(timeout));
				if (result == task)
				{
					// Task completed within timeout.
					return task.GetAwaiter().GetResult();
				}
				else
				{
					// Task timed out.
					throw new TimeoutException();
				}
			}
		}
	}
		
