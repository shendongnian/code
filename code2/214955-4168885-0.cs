    class StopWatch
    {
        [Conditional("DEBUG")]
        public void Start() { }
    
        [Conditional("DEBUG")]
        public void Stop() { }
    }
