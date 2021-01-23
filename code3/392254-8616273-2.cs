	private void button1_Click(object sender, EventArgs e)
	{
		BackgroundWorker worker = new BackgroundWorker;
        worker.WorkerReportsProgress = true;
		worker.ProgressChanged += ProgressChanged;
		worker.DoWork += ReadStream;
		worker.RunWorkerAsync(comboBox1.Text);
	}
	private void ProgressChanged(object sender, ProgressChangedEventArgs e)
	{
		UpdateProgressBar(e.ProgressPercentage);
        comboBox1.Text = e.UserState.ToString();
	}
	private void ReadStream(object sender, DoWorkEventArgs doWorkEventArgs)
	{
		BackgroundWorker worker = sender as BackgroundWorker;
		string line;
        string comboBoxText = doWorkEventArgs.Argument.ToString();
		using (StreamReader sr = new StreamReader("file", System.Text.Encoding.ASCII))
		{
			while (!sr.EndOfStream)
			{
				line = sr.ReadLine();
				worker.ReportProgress(line.Length);
                worker.ReportProgress(line.Length, "NEW COMBOBOX TEXT");
			}
		}
	}
