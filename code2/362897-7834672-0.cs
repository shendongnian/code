    public class MyWorker
    {
		private readonly ManualResetEvent _stopEvent = new ManualResetEvent(false);
		public void Stop()
		{
			_stopEvent.Set();
		}
		private bool Running
		{
			return !_stopEvent.WaitOne(0);
		}
		public MyWorker()
		{
		}
		
		public void MainLoop()
		{
		
			while (Running)
			{
			
				DoExtensiveWork1();
				if (!Running) return;
				
				DoExtensiveWork2();
				if (!Running) return;
				DoExtensiveWork3();
				if (!Running) return;
				DoExtensiveWork4();
				if (!Running) return;
				DoExtensiveWork5();			
				if (!Running) return;
				
				// We have to wait fifteen minutes (900 seconds) 
				// before another "run" can be processed
				if (_stopEvent.WaitOne(900000)) return;
			}
		}
	}
