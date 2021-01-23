        ManualResetEvent _requestTermination = new ManualResetEvent(false);
        Thread _thread;
        public void Init()
        {
            _thread = new Thread(() =>
             {
                 while (!_requestTermination.WaitOne(0))
                 {
                     // do something usefull
                 }
             }));
            _thread.Start();
        }
        public void Dispose()
        {
            _requestTermination.Set();
            // you could enter a maximum wait time in the Join(...)
            _thread.Join();
        }
