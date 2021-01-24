	private sealed class SingleThreadSynchronizationContext : SynchronizationContext
	{
		private readonly BlockingCollection<KeyValuePair<SendOrPostCallback, object>> _queue =
			new BlockingCollection<KeyValuePair<SendOrPostCallback, object>>();
		public override void Post(SendOrPostCallback d, object state) 
			=> _queue.Add(new KeyValuePair<SendOrPostCallback, object>(d, state));
		public void RunOnCurrentThread()
		{
			KeyValuePair<SendOrPostCallback, object> workItem;
			while (_queue.TryTake(out workItem, Timeout.Infinite))
				workItem.Key(workItem.Value);
		}
		public void Complete() => _queue.CompleteAdding();
	}
