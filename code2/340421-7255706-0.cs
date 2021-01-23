        public static void Main(string[] args)
        {         
            BackgroundWorker worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.ProgressChanged += ReportProgress;
            worker.RunWorkerCompleted += ProgressComplete;
            worker.DoWork += DoWork;
            worker.RunWorkerAsync();
        }
        private static void DoWork(object sender, DoWorkEventArgs doWorkEventArgs)
        { 
            //Runs on seperate thread
            //Do stuff
            //(sender as BackgroundWorker).ReportProgress... reports back to main thread
            //Do other stuff
        }
        private static void ProgressComplete(object sender, RunWorkerCompletedEventArgs e)
        {
            //Executed on main thread
            Console.Out.WriteLine("All Done");
        }
        private static void ReportProgress(object sender, ProgressChangedEventArgs e)
        {
            //Can be used to asynchronously send status updates or update UI elements on the main thread
            Console.Out.WriteLine("{0:P} done", e.ProgressPercentage/100.0);
        }
