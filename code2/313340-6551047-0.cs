        public delegate R AsyncTask<R>();
        public static AsyncTask<R> BeginTask<R>(AsyncTask<R> function)
        {
            R retv = default(R);
            bool completed = false;
            object sync = new object();
            
            IAsyncResult asyncResult = function.BeginInvoke(
                    iAsyncResult =>
                    {
                        lock (sync)
                        {
                            completed = true;
                            retv = function.EndInvoke(iAsyncResult);
                            Monitor.Pulse(sync); 
                        }
                    }, null);
            return delegate
            {
                lock (sync)
                {
                    if (!completed)               
                    {
                        Monitor.Wait(sync); 
                    }
                    return retv;
                }
            };
        }
