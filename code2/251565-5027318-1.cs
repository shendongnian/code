    public class TimeInterval
    {
        private readonly DateTime _start;
        private readonly DateTime _end;
    
        public DateTime Start { get { return _start; } }
        public DateTime End { get { return _end; } }
        public TimeSpan Duration { get { return _end - _start; } }
    
        public TimeInterval(DateTime start, DateTime end)
        {
            if(end < start)
              throw new ArgumentException("Incompatible DateTimes");
            _start = start;
            _end = end;
        }
        
        public TimeInterval(DateTime start, TimeSpan duration)
        {
            _start = start;
            _end = start.Add(duration);
        }
    }
