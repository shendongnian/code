    public class Example
    {
        ManualResetEvent _myEvent = new ManualResetEvent(false);
        Thread _myThread;
        bool _isRunning = true;
    
        public Example()
        {
            _myThread = new Thread(WorkerFunc);
            _myThread.Start();
        }
    
    
        public void WorkerFunc()
        {
            while (_isRunning)
            { 
                try
                {
                    _myEvent.Wait(Timeout.Infinite);
                    _myEvent.Reset();
                    ActualFunc();
                }
                catch (ThreadAbortException) { return; }
                catch (Exception err)
                {
                     _logger.Error("Thread func failed, lucky we caught it so the server don't die..", err);
                }
            }
        }
    
        public void Stop()
        {
           _isRunning = false;
           _myEvent.Set();
           _myThread.Join();
        }
    
        public void DoWork()
        {
            //add some work to the thread job queue or something
            _myEvent.Set();
        }
    
        private void ActualFunc()
        {
             //actual thread work is done here
             // in a seperate method to keep everything clean.
        }
    }
