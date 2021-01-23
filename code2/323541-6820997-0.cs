        public async void AsyncSwitchToCPU()    {
        Console.WriteLine("On the UI thread.");
     
        // Switch to a thread pool thread:
        await new SynchronizationContext().SwitchTo();  
                     
        Console.WriteLine("Starting CPU-intensive work on background thread...");
        int result = DoCpuIntensiveWork();
        Console.WriteLine("Done with CPU-intensive work!");
     
        // Switch back to UI thread
        await Application.Current.Dispatcher.SwitchTo();                
     
        Console.WriteLine("Back on the UI thread.  Result is {0}.", result);
    }
     
    public int DoCpuIntensiveWork()
    {
        // Simulate some CPU-bound work on the background thread:
        Thread.Sleep(5000);
        return 123;
    }
