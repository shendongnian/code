    class Program
    {
        private static BackgroundWorker worker = new System.ComponentModel.BackgroundWorker();
        private static AutoResetEvent resetEvent = new AutoResetEvent(false);
        static void Main(string[] args)
        {
            worker.DoWork += worker_DoWork;
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;
            worker.ProgressChanged += worker_ProgressChanged;
            worker.WorkerReportsProgress = true;
            Console.WriteLine("Starting Application...");
            worker.RunWorkerAsync();
            resetEvent.WaitOne();
            Console.ReadKey();
        }
        static void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Console.WriteLine(e.ProgressPercentage.ToString());
        }
        static void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            Console.WriteLine("Starting to do some work now...");
            int i;
            for (i = 1; i < 10; i++)
            {
                Thread.Sleep(1000);
                worker.ReportProgress(Convert.ToInt32((100.0 * i) / 10));
            }
            e.Result = i;
            resetEvent.Set();
        }
        static void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Console.WriteLine("Value Of i = " + e.Result.ToString());
            Console.WriteLine("Done now...");
        }
    }
