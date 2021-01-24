	private void DoSomeWork()
	{
		Task.Run(WorkerProc);
	}
	private async Task WorkerProc()
	{
		this.Busy = true;
		for (int i = 0; i < 100; i++)
		{
			// simulate loading a photo in 500ms
			var photo = i.ToString();
			await Task.Delay(TimeSpan.FromMilliseconds(500));
			// add it to the main collection
			Application.Current.Dispatcher.Invoke(() => this.Photos.Add(photo));
		}
		this.Busy = false;
	}
