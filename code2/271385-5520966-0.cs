	class Program
	{
		static void Main()
		{
			var worker = new BackgroundWorker {WorkerReportsProgress = true};
			worker.DoWork += DoWork;
			worker.ProgressChanged += ReportProgress;
			worker.RunWorkerAsync(5);
			Console.ReadKey();
		}
		private static void DoWork(object sender, DoWorkEventArgs e)
		{
			int count = (int) e.Argument;
			for (int i = 1; i <= count; i++)
			{
				(sender as BackgroundWorker).ReportProgress(i);
				Thread.Sleep(5000); // Do your work
			}
		}
		private static void ReportProgress(object sender, ProgressChangedEventArgs e)
		{
			Console.WriteLine("Tick " + e.ProgressPercentage);
		}
	}
