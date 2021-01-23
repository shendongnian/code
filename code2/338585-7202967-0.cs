        private void button1_Click(object sender, RoutedEventArgs e)
		{
			BackgroundWorker worker = new BackgroundWorker();
			worker.DoWork += new DoWorkEventHandler(worker_DoWork);
			worker.RunWorkerAsync();
		}
		void worker_DoWork(object sender, DoWorkEventArgs e)
		{
			for (int i = 0; i < 10; i++ )
			{
				Thread.Sleep(500);
				Dispatcher.Invoke(new Action(() => { this.progressBar1.Value++; }));
			}
		}
