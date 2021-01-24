	public class Program
	{
		public static async Task Test1()
		{
			Task<Data> task;
			using (var gateway = new Gateway())
			{
				task = gateway.Request1();
				await Task.Delay(1000);
			}
			var data = await task;
			Console.WriteLine("Test 1 is complete.");
		}
		public static async Task Test2()
		{
			Task<Data> task;
			using (var gateway = new Gateway())
			{
				task = gateway.Request2();
				await Task.Delay(1000);
			}
			var data = await task;
			Console.WriteLine("Test 2 is complete.");
		}
		public static async Task MainAsync()
		{
			await Test1();
			await Test2();
		}
		public static void Main()
		{
			MainAsync().GetAwaiter().GetResult();
			Console.WriteLine("Run completed at {0:yyyy-MM-dd HH:mm:ss}", DateTime.Now);
		}
	}
