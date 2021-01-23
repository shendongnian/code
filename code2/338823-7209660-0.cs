	public Form1()
	{
		InitializeComponent();
		// by creating a background thread, and then spawning the two func threads
		// from within, we eliminate needing to figure out how to properly handle
		// how to spawn spawn the update Invoke. 
		Thread BackgroundThread = 
			new Thread( 
			() =>
				{
					Thread Thread1 = 
						new Thread(() => { currentCount = Func1(); });
					Thread Thread2 = 
						new Thread(() => { allowedCount = Func2(); });
					Thread1.Start(); 
					Thread2.Start();
					// since we just wait in this thread until both 
					// other threads are finished, it should be very
					// fast to get to the final update once the threads
					// return.
					Thread1.Join();
					Thread2.Join();
					label2.Invoke(
					(Action)
					(
						() => { 
							label2.Text = string.Format(
								"Using {0} of {1}", 
								currentCount, allowedCount
							); 
						}
					)
					);
				}
			);
                
		// since all the thread code was handled in the one place via the internal 
		// function definitions via lambda, including the invoke, nothing major
		// left, just fire the function off and everything goes through.
		BackgroundThread.Start();
	}
