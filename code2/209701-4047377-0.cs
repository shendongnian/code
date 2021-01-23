	private AutoResetEvent _resetEvent = new AutoResetEvent(false);
	private void radioButton_CheckedChanged(object sender, EventArgs e)
	{
		RadioButton rb = sender as RadioButton;
		if (rb.Checked)
		{
			if (backgroundWorker1.IsBusy)
			{
				backgroundWorker1.CancelAsync();
				_resetEvent.WaitOne(); // will block until _resetEvent.Set() call made
			}
			backgroundWorker1.RunWorkerAsync();
		}
	}
	private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
	{
		BackgroundWorker worker = sender as BackgroundWorker;
		for (int i = 0; i < 100 && !worker.CancellationPending; ++i)
			Thread.Sleep(1);
		if (worker.CancellationPending)
		{
			e.Cancel = true;
		}
		_resetEvent.Set();
	}
