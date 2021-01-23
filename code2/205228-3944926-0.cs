    public void DoWork(object state) 
    {
       ThreadSignal signal = (ThreadSignal)state;
       while(!signal.Stop)
       {
          // Do work here    
       }
    }
