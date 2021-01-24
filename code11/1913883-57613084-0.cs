    new Thread(DoSth).Start();
    private readonly object protect = new object();
    public async Task DoSth()
    {
       public static AutoResetEvent waitEvent = new AutoResetEvent(true);
       while(true)
       {
           bool triggered = false;
           lock(protect)
           {
               Monitor.Wait(protect, seconds * 1000);
               triggered = shouldWork;
               shouldWork = false;
           }
           if(triggered) 
               Work();
      }
    }
    public void Trigger()
    {
        lock(protect)
        {
            shouldwork = true;
            Monitor.Pulse(protect);//will end the wait on the other thread
        }
    }
