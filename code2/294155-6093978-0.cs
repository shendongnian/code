        public static Func<R> HandleInvoke<T, R>(this Func<T, R> function, T arg)
        {
            R retv = default(R);
            bool completed = false;
            object sync = new object();
            IAsyncResult asyncResult = function.BeginInvoke(arg, 
                iAsyncResult =>
                {
                    lock(sync)
                    {
                        completed = true;
                        retv = function.EndInvoke(iAsyncResult);
                        Monitor.Pulse(sync); // wake a waiting thread is there is one
                    }
                }
                , null);
            return delegate
            {
                lock (sync)
                {
                    if (!completed) // if not called before the callback completed
                    {
                        Monitor.Wait(sync); // wait for it to pulse the sync object
                    }
                    return retv;
                }
            };
        }
