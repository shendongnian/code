    public void Stop() 
    {
        lock (locker)
        {
            isStopping = true;
        }
        resetEvent.WaitOne(); //initially set to true
        listener.Stop();
    }
    private void ListenerCallback(IAsyncResult ar)
    {
        lock (locker) //locking on this is a bad idea, but I forget about it before
        {
            if (isStopping)
                return;
    
            resetEvent.Reset();
            numberOfRequests++;
        }
        
        try
        {
            var listener = ar.AsyncState as HttpListener;
    
            var context = listener.EndGetContext(ar);
    
            //do some stuff
        }
        finally //to make sure that bellow code will be executed
        {
            lock (locker)
            {
                if (--numberOfRequests == 0)
                    resetEvent.Set();
            }
        }
    }
