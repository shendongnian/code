    public class EmailRateHelper
    {
        private int _requestsPerInterval;
        private Queue<DateTime> _history;
        private TimeSpan _interval;
        public EmailRateHelper()
        	: this(30, new TimeSpan(0, 1, 0)) { }
        public EmailRateHelper(int requestsPerInterval, TimeSpan interval)
        {
            _requestsPerInterval = requestsPerInterval;
            _history = new Queue<DateTime>();
            _interval = interval;
        }
        public void SleepAsNeeded()
        {
            DateTime now = DateTime.Now;
            _history.Enqueue(now);
            if (_history.Count >= _requestsPerInterval)
            {
                var last = _history.Dequeue();                
                TimeSpan difference = now - last;
                if (difference < _interval)
                {
                	System.Threading.Thread.Sleep(_interval - difference);
        		}
            }
        }
    }
