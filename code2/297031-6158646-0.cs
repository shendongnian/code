    internal class Program
	{
		// continue to call this function until the user presses a 
		// key to terminate the application
		private static void PrintTime(object state)
		{
			Console.WriteLine("Time is: {0}",
			                  DateTime.Now.ToLongTimeString());
		}
		private static void Main(string[] args)
		{
			TimerCallback timeCB = new TimerCallback(PrintTime);
			Timer t = new Timer(
				timeCB,
				null,
				0,
				1000);
			WeakReference wk = new WeakReference(t);
			PrintStatus(wk);
			Console.WriteLine("Hit key to terminate...");
			Console.ReadLine();
			t = null;
			PrintStatus(wk);
		}
		private static void PrintStatus(WeakReference wk)
		{
			GC.Collect();
			GC.WaitForPendingFinalizers();
			Console.WriteLine("Is timer alive? " + wk.IsAlive);
		}
	}
