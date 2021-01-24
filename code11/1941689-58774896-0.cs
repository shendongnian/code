	private readonly object myLock = new object();
	
	private void VideoSource_NewFrame(object sender, NewFrameEventArgs eventArgs)
	{
		lock (myLock) {
			this.Invoke((Action)(() => {
				if (pictureBox1.Image != null)
					((IDisposable)pictureBox1.Image).Dispose();
				pictureBox1.Image = (Bitmap)eventArgs.Frame.Clone();		
			
			}));
		}
	}
	
	private void timer1_Tick(object sender, EventArgs e)
	{
		timer1.Stop();
		
		// you can try with timer1 inside the lock
		lock (myLock) {
			// you don't need invoke here, because the winforms timer runs on the main thread.
			Capturing();	
		}
		
		timer1.Start();
	}
