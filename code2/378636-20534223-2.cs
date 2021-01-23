	// This approach makes WPF Windows an order of magnitude more responsive
	Thread t = new Thread(() =>
	{
		try
		{
			// Implement the IDisposable pattern on your window to release
			//   any resources before the thread exits
			using (var myWindow = new MyWindow())
			{
				// Do any other pre-display initialization with the myWindow
				//   object here...
				myWindow.ShowDialog();
			}
		}
		finally
		{
			// Strongly Recommended (not doing this may cause
			//   weird exceptions at application shutdown):
			Dispatcher.CurrentDispatcher.InvokeShutdown();
		}
	});
	t.SetApartmentState(ApartmentState.STA); // Required
	t.IsBackground = false; // Recommended
	t.Start(); // Kicks off the new UI thread
	t.Join();  // Blocks execution until the new UI thread has finished executing...
