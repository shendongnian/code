	Task.Factory.StartNew(() =>
	{
		Thread.Sleep(500);
		this.Invoke((Action)(() =>
		{
			toolTip1.Show("my text", myControl);
		}));
	}, TaskCreationOptions.LongRunning);
