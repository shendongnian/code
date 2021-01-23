    public class WaitableWorker
        {
            private readonly Action callback;
            private readonly Timer timer;
            private readonly AutoResetEvent evt;
            public WaitableWorker(long interval, Action callback,bool blockingMode=false)
            {
                this.callback = callback;
    
                timer = new Timer(_ => evt.Set(),
                                  null, interval, Timeout.Infinite);
                
                evt = new AutoResetEvent(false);
                if(!blockingMode)
                    ThreadPool.QueueUserWorkItem((a) => Perform(), null);
                else
                {
                    Perform();
                }
            }
    
            private void Perform()
            {
                evt.WaitOne();
                evt.Dispose();
                timer.Dispose();
                callback();
            }
        }
