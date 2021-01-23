    public class MyWorker
    {
		private readonly ManualResetEvent _stopEvent = new ManualResetEvent(false);
		private readonly Action[] _workUnits;
		private bool Running
		{
			get { return !_stopEvent.WaitOne(0); }
		}
		public MyWorker()
		{
			_workUnits = new Action[]
			{
				DoExtensiveWork1,
				DoExtensiveWork2,
				DoExtensiveWork3,
				DoExtensiveWork4,
				DoExtensiveWork5
			};
		}
		
		public void Stop()
		{
			_stopEvent.Set();
		}
		public void MainLoop()
		{
		
			while (Running)
			{
				foreach (var workUnit in _workUnits)
				{
					workUnit();
					if (!Running) return;
				}			
				// We have to wait fifteen minutes (900 seconds) 
				// before another "run" can be processed
				if (_stopEvent.WaitOne(900000)) return;
			}
		}
	}
