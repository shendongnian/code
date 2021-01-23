	public class Invoker
	{
		private Queue<Action> Actions { get; set; }
		public Invoker()
		{
			this.Actions = new Queue<Action>();
		}
		public void Execute()
		{
			while (this.Actions.Count > 0)
			{
				this.Actions.Dequeue()();
			}
		}
		public void Invoke(Action action, bool block = true)
		{
			if (block)
			{
				SemaphoreSlim semaphore = new SemaphoreSlim(1);
				bool disposed = false;
				this.Actions.Enqueue(delegate
				{
					action();
					semaphore.Release();
					lock (semaphore)
					{
						semaphore.Dispose();
						disposed = true;
					}
				});
				lock (semaphore)
				{
					if (!disposed)
					{
						semaphore.Wait();
						semaphore.Dispose();
					}
				}
			}
			else
			{
				this.Actions.Enqueue(action);
			}
		}
	}
