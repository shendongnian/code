	using System.Threading;
    class MyConversionClass :
		EventArgs
	{
		public YCBCR Input;
		public RGB Output
		
		private EventHandler Completed;
		private Thread Thread1;
		private Thread Thread2;
		private Thread Thread3;
		private SynchronizationContext SyncContext;
		private volatile int pCompletionCount;
		public MyConversionClass()
		{
			this.Thread1 = new Thread(this.ComputeY);
			this.Thread2 = new Thread(this.ComputeCB);
			this.Thread3 = new Thread(this.ComputeCR);
		}
		
		public void Start(YCBCR myInput, RGB myOutput, SynchronizationContext syncContext, EventHandler completed)
		{
			this.SyncContext = syncContext;
			this.Completed = completed;
			this.Input = myInput;
			this.Output = myOutput;
			this.Thread1.Start();
			this.Thread2.Start();
			this.Thread3.Start();
		}
		// Call this method in background worker 1
		private void ComputeY()
		{
			... // for each pixel do My stuff
			if (Interlocked.Increment(ref this.CompletionCount) == 3)
				this.MergeTogether();
		}
		
		// Call this method in background worker 2
		private void ComputeCB()
		{
			... // for each pixel do My stuff
			if (Interlocked.Increment(ref this.CompletionCount) == 3)
				this.MergeTogether();
		}
		
		// Call this method in background worker 3
		private void ComputeCR()
		{
			... // for each pixel do My stuff
			if (Interlocked.Increment(ref this.CompletionCount) == 3)
				this.MergeTogether();
		}
		
		private void MergeTogether()
		{
			... // We merge the three channels together
			
			// We finish everything, we can notify the application that everything is completed.
			this.syncContext.Post(RaiseCompleted, this);
		}
		
		private static void RaiseCompleted(object state)
		{
			(state as MyConversionClass).OnCompleted(EventArgs.Empty);
		}
		
		// This function is called in GUI thread when everything completes.
		protected virtual void OnCompleted(EventArgs e)
		{
			EventHandler completed = this.Completed;
			this.Completed = null;
			if (completed != null)
				completed(this, e);
		}
	}
	
