        public void SetReady()
        {
            lock (syncObj)
            {
                ready = true;
                Monitor.Pulse(syncObj);
            }
            
        }
            public bool TryWait(int milliseconds)
            {
                bool result = true;
                lock(syncObj)
                {
                    while (!ready)
                    {
                        result = Monitor.Wait(syncObj, milliseconds);
                    }
                }
                return result;
            }
    
            public void Wait()
            {
                lock (syncObj)
                {
                    while (!ready)
                    {
                        Monitor.Wait(syncObj);
                    }
                }
            }
