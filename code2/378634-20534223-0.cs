	// Gets or creates a dispatcher for the current thread -- we should access 
	//   our office RCWs through invokes to this dispatcher...
	var officeDispatcher = Dispatcher.CurrentDispatcher;
	// This approach makes WPF Windows an order of magnitude more responsive
	Thread t = new Thread(() =>
	{
		// Implement the IDisposable pattern on your window to get rid of
		//   any COM objects before the thread exits
		using (var myWindow = new MyWindow())
		{
			// Give your window an OfficeDispatcher property, use this to
			//   access the VSTO RCWs (i.e. OfficeDispatcher.Invoke(...)) 
			//   -- this isn't required, but it may save you headaches in
			//   the long run...
			myWindow.OfficeDispatcher = officeDispatcher;
			// Do any other pre-display initialization with the myWindow
			//   object here...
			myWindow.ShowDialog();
		}
		// Helps ensure we don't leave any RCWs floating around
		GC.Collect();
	});
	t.SetApartmentState(ApartmentState.STA); // Required
	t.IsBackground = false; // Recommended
	t.Start(); // Kicks off the new UI thread
	t.Join();  // Blocks execution until the new UI thread has finished executing...
