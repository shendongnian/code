    public class TimePeriod
	{
		private readonly DateTime? _startDate;
		private readonly DateTime? _endDate;
		private readonly TimeSpan _timeSpan;
		public TimePeriod(DateTime startDate, DateTime endDate)
		{
			if (_startDate > _endDate)
			{
				throw new ArgumentException();
			}
			_startDate = startDate;
			_endDate = endDate;
			_timeSpan = endDate - startDate;
		}
		public TimePeriod(TimeSpan timeSpan)
		{
			_timeSpan = timeSpan;
		}
		public TimeSpan TimeSpan
		{
			get { return _timeSpan; }
		}
		public DateTime? StartDate
		{
			get { return _startDate; }
		}
		public DateTime? EndDate
		{
			get { return _endDate; }
		}
		public bool IsAbsolute
		{
			get { return _startDate.HasValue; }
		}
	}
