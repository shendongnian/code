    private void Run()
    {
        while (true)
        {
            ... 
       
            // Need attention from the main thread
            // "_main" is the main thread's Dispatcher instance.
            _main.BeginInvoke(new MyEventHandler(OnNeedsAttention), this, new MyEventArgs(...));
            try
            {
                Thread.Sleep(Timeout.Infinite);
            }
            catch (ThreadInterruptedException) { }
        }
    }
