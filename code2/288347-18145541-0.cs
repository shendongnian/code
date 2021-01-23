        ManualResetEvent _requestTermination = new ManualResetEvent(false);
        ManualResetEvent _terminated = new ManualResetEvent(false);
        public void Init()
        {
            new Thread(new ThreadStart(() =>
             {
                 while (!_requestTermination.WaitOne(0))
                 {
                     // do something usefull
                 }
                 _terminated.Set();
             })).Start();
        }
        public void Dispose()
        {
            _requestTermination.Set();
            // you could enter a maximum wait time in the WaitOne(...)
            _terminated.WaitOne();
        }
