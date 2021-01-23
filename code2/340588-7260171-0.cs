    ManualThreadEvent terminate = new ManualThreadEvent(false);
    bool someBoolean = false;
    
    void someMethod(param1, param2....)
    {
        try{
         // wait for enough data or for termination:
         while(terminate.WaitOne(100) == false && stream.DataAvaiable <= bytesNeeded) 
         { /* nothing to do here */ }
         if (terminate.WaitOne(0)) return; // terminate on request
    
         // To your stuff with read
        }catch{}//
    }
    
    void Terminate()
    {
      terminate.Set();
    }
