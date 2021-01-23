    public class WaitableWorker
        {
            private readonly System.Threading.Timer timer;
            public WaitableWorker(int interval, Action callback, bool blocking = false)
            {
                if (blocking)
                {
                    Thread.Sleep(interval);
                    callback();
                }
                else
                {
                    timer = new System.Threading.Timer(_ =>
                                                           {
                                                               timer.Dispose();
                                                               callback();
                                                           },
                                                       null, interval, Timeout.Infinite);
                }
            }
    
        }
    
