    class Program
    {
        Exception _savedException = null;
        AutoResetEvent _exceptionEvent = new AutoResetEvent(false);
        static void Main(string[] args)
        {
            Program program = new Program();
            program.RunMain();
        }
        void RunMain()
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(ThreadMethod));
            while (true)
            {
                _exceptionEvent.WaitOne();
                if (_savedException != null)
                {
                    throw _savedException;
                }
            }
        }
        void ThreadMethod(object contxt)
        {
            try
            {
                // do something that can throw an exception
            }
            catch (Exception ex)
            {
                _savedException = ex;
                _exceptionEvent.Set();
            }
        }
    }
