	public class OwnerClass
	{
		private SynchronizationContext syncContext;
		private int count;
		private int completedCount;
		
		// This event will be raised when all thread completes
		public event EventHandler Completed;
		
		public OwnerClass() :
			this(SynchronizationContext.Current)
		{
		}
		
		public OwnerClass(SynchronizationContext context)
		{
			if (context == null)
				throw new ArgumentNullException("context");
			this.syncContext = context;
		}
		
		// Call this method to start running
		public void Run(int threadsCount)
		{
			this.count = threadsCount; 
			for (int i = 0; i < threadsCount; ++i)
			{
				ThreadPool.QueueUserWorkItem(this.ThreadFunc, null);
			}
		}
		
		private void ThreadFunc(object threadContext)
		{
			Thread.Sleep(1000); /// my long and complicated function
			
			if (Interlocked.Increment(ref this.completedCount) >= this.count)
			{
				this.syncContext.Post(OnCompleted, null);
			}
		}
		
		protected virtual void OnCompleted(object state)
		{
			var handler = this.Completed;
			if (handler != null)
				handler(this, EventArgs.Empty);
		}
	}
