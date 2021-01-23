	public class PollingWorker : IDisposable
	{
		
		private const int DEFAULT_INTERVAL_MS = 1000; // 1 second 
		private const int WAIT_INTERVAL = 20; // MS
		private Thread _labourer = null;
		private int _pollingIntervalMS = DEFAULT_INTERVAL_MS;
		private ParameterizedThreadStart _work = null;
		private bool _working = false;
		private object _state = new object();
		private AutoResetEvent _resetTimer = new AutoResetEvent(false);
		private bool _itsTimeToQuite = false;
		private bool _poked = false;
		private bool _isCurrentlyWorking = false;
	
		public string Name
		{
			get { return _labourer.Name; }
			set { _labourer.Name = value; }
		}
		public PollingWorker(int intervalMS, ParameterizedThreadStart work, object state):
			this(intervalMS, work, state, Guid.NewGuid().ToString())
		{
		}
		public PollingWorker(int intervalMS, ParameterizedThreadStart work, object state, string name)
		{
			_pollingIntervalMS = intervalMS;
			_labourer = new Thread(new ThreadStart(TryDoingSomeWork));
			_labourer.Name = name;
			_work = work;
		}
		public int PollingIntervalMS
		{
			get { return _pollingIntervalMS; }
			set 
			{
				_pollingIntervalMS = value; 
			}
		}
		public void StartWork()
		{
			StartWork(true);
		}
		public void StartWork(bool initialWait)
		{
			_working = true;
			_poked = !initialWait;
			_labourer.Start();
		}
		public void PauseWork()
		{
			_working = false;
		}
		public void Quit()
		{
			Quit(int.MaxValue);
		}
		public void Quit(int maximumWaitToFinishCurrentWorkMS)
		{
			int totalWait = 0;
			_itsTimeToQuite = true;
			_working = false;
			_resetTimer.Set();
			while (_isCurrentlyWorking && Thread.CurrentThread.Name != _labourer.Name) // in case Quit is called from Work 
			{
				Thread.Sleep(WAIT_INTERVAL);
				totalWait += WAIT_INTERVAL;
				if(totalWait>maximumWaitToFinishCurrentWorkMS)
					break;
			}
			Dispose();
		}
		// poke to wake up !
		public void Poke()
		{
			try
			{
				// if you call set on the same thread while it is not on waitOne
				// it does not work 
				if (Thread.CurrentThread.Name == this.Name)
					//_resetTimer.Set();
					_poked = true;
				else
					_resetTimer.Set();
			}
			catch
			{ 
				// ignore any error with poking 
			}
		}
		private void TryDoingSomeWork()
		{
			while (!_itsTimeToQuite)
			{
				//Debug.WriteLine(string.Format("{0:ss fff}\t{1}\t{2}\t{3}", DateTime.Now, this.Name, string.Empty, string.Empty));
				if (!_poked) 
					_resetTimer.WaitOne(_pollingIntervalMS, false);
				_poked = false;
				// timed-out which means timer's pulse, so do some work 
				if (_working)
				{
					_isCurrentlyWorking = true;
					_work(_state);
					_isCurrentlyWorking = false;
				}		
			}
		}
		public object State
		{
			get { return _state; }
			set 
			{
				lock (_state)
				{
					_state = value; 				
				}
			}
		}
		public bool Working
		{
			get { return _working; }
		}
		#region IDisposable Members
		public void Dispose()
		{
			try
			{
				_resetTimer.Close();
				_labourer.Abort();
			}
			catch
			{ 
				// dont want to raise errors now 
				// so ignore especially threadabortexception!!
			}
		}
		#endregion
	}
