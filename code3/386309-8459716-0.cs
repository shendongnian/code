    public class OneCallAtATimeClass
    {
    
        private object syncObject;
    
        public TimerExample()
        {
          syncObject = new object();
        }
    
        public void CalledFromTimer()
        {
          bool enterMonitor = Monitor.TryEnter(syncObject);
    
          try
          {
            if (enterMonitor)
            {
              InternalImplementation();
            }
          }
          finally
          {
            if (enterMonitor)
            {
              Monitor.Exit(syncObject);
            }
          }
    
    
        }
    
        private void InternalImplementation()
        {
          //Do some logic here
        }
    
      }
