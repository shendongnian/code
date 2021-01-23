    public class Countdown
    {
        public DateTime Time { get; set; }
        public event Action Elapsed { get; set; }
        public void RaiseElasped()
        {
            if(Elapsed != null)
                Elapsed();
        }
    }
