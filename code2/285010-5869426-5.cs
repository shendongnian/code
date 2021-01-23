	public sealed class SimpleSemaphore
	{
		readonly object sync = new object();
		public int val;
		public void WaitOne()
		{
			lock(sync) {
				while(true) {
					if(val > 0) {
						val--;
						return;
					}
					Monitor.Wait(sync);
				}
			}
		}
	
		public void Release()
		{
			lock(sync) {
				if(val==int.MaxValue)
					throw new Exception("Too many releases without waits.");
				val++;
				Monitor.Pulse(sync);
			}
		}
	}
