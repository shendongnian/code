	private class TransactionIdProvider
	{
		private volatile int _initialized;
		private int _transactionId;
		public int NextId
		{
			get
			{
				for (;;)
				{
					switch (_initialized)
					{
						case 0: throw new Exception("Not initialized");
						case 1: return Interlocked.Increment(ref _transactionId);
						default: Thread.Yield();
					}
				}
			}
		}
		
		public void SetId(int id)
		{
			if (Interlocked.CompareExchange(ref _initialized, -1, 0) == 0)
			{
				Interlocked.Exchange(ref _transactionId, id);
				Interlocked.Exchange(ref _initialized, 1);
			}
		}
	}
