    public class EmailRateHelper
    {
        private int RequestsPerInterval = 30;
        private Queue<DateTime> History = new Queue<DateTime>();
        private TimeSpan Interval = new TimeSpan(0, 1, 0);
        public EmailRateHelper() { }
        public EmailRateHelper(int RequestsPerInterval, TimeSpan Interval)
        {
            this.RequestsPerInterval = RequestsPerInterval;
            this.Interval = Interval;
        }
        public void SleepAsNeeded()
        {
            DateTime _Now = DateTime.Now;
            History.Enqueue(_Now);
            if (History.Count >= RequestsPerInterval)
            {
                var _Last = History.Dequeue();                
                TimeSpan Difference = _Now - _Last;
                if (Difference < Interval)
                    System.Threading.Thread.Sleep(Interval - Difference);
            }
        }
    }
