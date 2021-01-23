    private System.Threading.ManualResetEvent STOP = new System.Threading.ManualResetEvent(false);
    public void Start()
    {
         while(true)
         {
              //do some work
			  if(STOP.WaitOne(15000))
				break;
         }
    }
    public void Stop()
    {
		STOP.Set();
    }
