	public class MyService
	{
		private IDisposable Timer;
		
		public void Start()
		{
			Timer = ObservableHelpers
				.CreateMinutePulse(15)		// check every 15 seconds if it's a new minute
				.Subscribe(i => DoSomething());
		}
		
		public void Stop()
		{
			if(Timer != null)
			{
				Timer.Dispose();
				Timer = null;
			}
		}
		
		public void DoSomething()
		{
			// do your thing here
		}
	}
	
	public static class ObservableHelpers
	{
		/// <summary>
		///     Returns an observable that pulses every minute with the specified resolution.
		///     The pulse occurs within the amount of time specified by the resolution (in seconds.)
		///     Higher resolution (i.e. lower specified number of seconds) may affect execution speed.
		/// </summary>
		/// <returns></returns>
		public static IObservable<int> CreateMinutePulse(int resolution)
		{
			return Observable
				.Interval(TimeSpan.FromSeconds(resolution.SetWithinRange(1, 59)))
				.Select(i => DateTime.Now.Minute)
				.DistinctUntilChanged();
		}
	}
