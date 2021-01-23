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
            // This task simulates an asynchronous call that will invoke
            // Stop_Callback upon completion. In real code you will probably
            // have something like this instead:
            //
            //     someObject.DoSomethingAsync("input", Stop_Callback);
            //
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
