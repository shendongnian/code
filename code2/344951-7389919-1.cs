        public void SetReady()
        {
            lock (syncObj)
            {
                ready = true;
                Monitor.Pulse(syncObj);
            }
            
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
