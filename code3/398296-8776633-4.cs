    class Poll : IDisposable
    {
        private TimeSpan polledSpan;
        WaitHandle[] handles = new WaitHandle[2];
        ManualResetEvent exit = new ManualResetEvent(false);
        Thread thread;
        public Poll(int polledTime)
        {
            polledSpan = new TimeSpan(0, 0, polledTime);
            thread = new Thread(new ThreadStart(Start));
            thread.Start();
        }
        private void Start()
        {            
            AutoResetEvent reset = new AutoResetEvent(false);
            handles[0] = reset;
            handles[1] = exit;
            bool run = true;
            while (run)
            {                
                int result = WaitHandle.WaitAny(handles, 
                                               (int)polledSpan.TotalMilliseconds, 
                                               false);
                switch(result)
                {
                    case WaitHandle.WaitTimeout:
                        run = StuffToDo();
                        break;
                    case 1:
                    case 0:
                        run = false;
                        break;
                }                
            }            
        }
        private bool StuffToDo()
        {
            try
            {
                Console.WriteLine("Test");
                return true;
            }
            catch
            {
                return false;
            }
        }
        public void Dispose()
        {
            exit.Set();
            if (thread != null)
            {
                thread.Join(10000);
            }
            exit = null;
            handles = null;
        }
    }
