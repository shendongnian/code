    class AsyncDemo
    {
        AutoResetEvent stopWaitHandle = new AutoResetEvent(false);
        public void SomeFunction()
        {    
            Stop();
            stopWaitHandle.WaitOne(); // wait for callback    
            Start();
        }
        private void Start()
        {
            // do something
        }
        private void Stop()
        {
            // invoke some asynchronous task that will 
            // finish by calling Stop_Callback
            new Task(() =>
                {
                    Thread.Sleep(500);
                    Stop_Callback(); // invoke the callback
                }).Start();
        }
    
        private void Stop_Callback()
        {
            // signal the wait handle
            stopWaitHandle.Set();
        }
    
    }
