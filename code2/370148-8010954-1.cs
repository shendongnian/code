        public Queue<ItemToPrint> PrintQueue = new Queue<ItemToPrint>();
		private BackgroundWorker bgwPrintWatcher;
		public void SetupBackgroundWorker()
		{
			bgwPrintWatcher = new BackgroundWorker();
			bgwPrintWatcher.WorkerSupportsCancellation = true;
			bgwPrintWatcher.ProgressChanged += new ProgressChangedEventHandler(bgwPrintWatcher_ProgressChanged);
			bgwPrintWatcher.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgwPrintWatcher_RunWorkerCompleted);
			bgwPrintWatcher.DoWork += new DoWorkEventHandler(bgwPrintWatcher_DoWork);
			bgwPrintWatcher.RunWorkerAsync();
		}
		void bgwPrintWatcher_DoWork(object sender, DoWorkEventArgs e)
		{
			BackgroundWorker worker = sender as BackgroundWorker;
			while (!worker.CancellationPending)
			{
				// Prevent writing to queue while we are reading / editing it
				lock (PrintQueue)
				{
					if (PrintQueue.Count > 0)
					{
						ItemToPrint item = PrintQueue.Dequeue();
						// Two options here, you can either sent it back to the main thread to print
						worker.ReportProgress(PrintQueue.Count + 1, item);
						// or print from the background thread
						Print(item);
					}
				}
			}
		}
		private void Print(ItemToPrint item)
		{
			// Print it here
		}
		private void AddItemToPrint(ItemToPrint item)
		{
			lock (PrintQueue)
			{
				PrintQueue.Enqueue(item);
			}
		}
		void bgwPrintWatcher_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			// Anything here will run from the main / original thread
			// PrintQueue will no longer be watched
		}
		void bgwPrintWatcher_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			// Anything here will run from the main / original thread
			ItemToPrint item = e.UserState as ItemToPrint;
			// e.ProgressPercentage holds the int value passed as the first param
			Print(item);
		}
