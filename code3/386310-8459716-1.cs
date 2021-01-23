    public class OneCallAtATimeClass
    {
    
        private object syncObject;
    
        public TimerExample()
        {
          syncObject = new object();
        }
    
        public void CalledFromTimer()
        {    
          if (Monitor.TryEnter(syncObject);)
          {
            try
            {
              InternalImplementation();
            }
            finally
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
