        void Run ()    
        {
            while (true)
            {
                Action doit = null;
     
                lock(_queueLock)
                {
                    while (_queue.IsEmpty())
                        Monitor.Wait(_queueLock);
    
                    TimeSpan timeDiff = _queue.First().Key - DateTime.Now;
                    if (timeDiff < 100ms)
                        doit = _queue.Dequeue();
                }
                if (doit != null)
                    ; //execute doit
  
            }
        }
    void ScheduleEvent (Action action, DataTime time)
    {
        lock (_queueLock)
        {
            _queue.Add(time, action);
            // Signal thread to wake up and check again
            //_sync.Set ();
            Monitor.Pulse(_queuLock);
        }
    }
