    class Stoper
    {
        public TimeSpan ElapsedTime { get; set; }
        private DateTime startDate;
        public void Start()
        {
            startDate = DateTime.Now;
        }
        public void Stop()
        {
            ElapsedTime = DateTime.Now - startDate;
        }
    }
