	private void button1_Click(object sender, EventArgs e)
	{
		BackgroundWorker worker = new BackgroundWorker { WorkerReportsProgress = true };
		worker.ProgressChanged += ProgressChanged;
		worker.DoWork += ReadStream;
		worker.RunWorkerAsync();
	}
	private void ProgressChanged(object sender, ProgressChangedEventArgs e)
	{
		UpdateProgressBar(e.ProgressPercentage);
	}
	private void ReadStream(object sender, DoWorkEventArgs doWorkEventArgs)
	{
		BackgroundWorker worker = sender as BackgroundWorker;
		string line;
		using (StreamReader sr = new StreamReader("file", System.Text.Encoding.ASCII))
		{
			while (!sr.EndOfStream)
			{
				line = sr.ReadLine();
				worker.ReportProgress(line.Length);
			}
		}
	}
