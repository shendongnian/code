    class Program
	{
		private static Timer timer;
		private static readonly Stopwatch stopwatch = new Stopwatch();
		static void Main(string[] args)
		{
			timer = new Timer(Tick);
			stopwatch.Start();
			timer.Change(30000, Timeout.Infinite);
			Console.ReadLine();
		}
		private static void Tick(object obj)
		{
			stopwatch.Stop();
			Console.WriteLine(stopwatch.Elapsed.Seconds);
		}
	}
