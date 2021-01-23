    class Program
	{
		static void Main(string[] args)
		{
			// Register hanlder to ProcessExit event
			AppDomain.CurrentDomain.ProcessExit += ProcessExitHanlder;
		}
		private static void ProcessExitHanlder(object sender, EventArgs e)
		{
			Console.WriteLine("Cleanup!");
		}
	}
