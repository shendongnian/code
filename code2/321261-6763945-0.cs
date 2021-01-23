    object mylock = new object();
    int count = 0;
    
    public void MethodA()
    {
        // record that MethodA is executing
        lock (mylock)
            count++;
    
        // other code...
    }
    
    public void MethodB()
    {
        // other code...
    
        lock (mylock)
        {
            // MethodB has now finished running
            count--;
    
            // wake up other thread because it may now be allowed to run
            Monitor.Pulse(mylock);
        }
    }
    
    public void BlockedMethod()
    {
        // wait until the number of calls to A and B is equal (i.e., count is 0)
        lock (mylock)
        {
            while (count != 0)
                 Monitor.Wait(mylock);
        }
    
        // calls to A and B are balanced, proceed...
    }
