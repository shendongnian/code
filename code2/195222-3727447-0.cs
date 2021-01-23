    sealed class Looper
    {
        public event EventHandler ProgressUpdated;
    
        private int _progress;
        public int Progress
        {
            get { return _progress; }
            private set
            {
                _progress = value;
                OnProgressUpdated();
            }
        }
    
        public void DoLoop()
        {
            _progress = 0;
            for (int i = 0; i < 100; ++i)
            {
                Thread.Sleep(100);
                Progress = i;
            }
        }
    
        private void OnProgressUpdated()
        {
            EventHandler handler = ProgressUpdated;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }
    }
