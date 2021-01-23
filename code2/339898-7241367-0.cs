    public struct TimeInterval
	{
		private readonly DateTime _startTime;
		private readonly DateTime _endTime;
		public DateTime StartTime { get { return _startTime; } }
		public DateTime EndTime { get { return _endTime; } }
		public TimeInterval(DateTime now)
		{
			_startTime = now.Date;
			_endTime = now.Date.AddDays(1).AddTicks(-1);
		}
	}
