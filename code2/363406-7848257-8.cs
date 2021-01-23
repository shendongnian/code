    using System.Threading;
    class MyConversionClass
	{
		public YCBCR Input;
		public RGB Output
		private Thread Thread1;
		private Thread Thread2;
		private Thread Thread3;
		private int pCompletionCount;
		public MyConversionClass(YCBCR myInput, RGB myOutput)
		{
			this.Input = myInput;
			this.Output = myOutput;
			this.Thread1 = new Thread(this.ComputeY);
			this.Thread2 = new Thread(this.ComputeCB);
			this.Thread3 = new Thread(this.ComputeCR);
		}
		
		public void Start()
		{
			this.Thread1.Start();
			this.Thread2.Start();
			this.Thread3.Start();
		}
		public void WaitCompletion()
		{
			this.Thread1.Join();
			this.Thread2.Join();
			this.Thread3.Join();
		}
		// Call this method in background worker 1
		private void ComputeY()
		{
			// for each pixel do My stuff
			...
			if (Interlocked.Increment(ref this.CompletionCount) == 3)
				this.MergeTogether();
		}
		
		// Call this method in background worker 2
		private void ComputeCB()
		{
			// for each pixel do My stuff
			...
			if (Interlocked.Increment(ref this.CompletionCount) == 3)
				this.MergeTogether();
		}
		
		// Call this method in background worker 3
		private void ComputeCR()
		{
			// for each pixel do My stuff
			...
			if (Interlocked.Increment(ref this.CompletionCount) == 3)
				this.MergeTogether();
		}
		
		private void MergeTogether()
		{
			// We merge the three channels together
			...
		}
	}
