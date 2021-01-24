         System.Threading.Mutex _mutex = null;
    bool mutexWasCreated = false;
                    public Form1()
                    {
                        new Thread(threadSafeWorkBetween2Instances).Start();
                    }
                    void threadSafeWorkBetween2Instances()
                    {
                         if(!_mutex.TryOpenExisting("GlobalsystemWideMutex"))
                         {
                            // Create a Mutex object that represents the system
                           // mutex named with
                           // initial ownership for this thread, and with the
                           // specified security access. The Boolean value that 
                           // indicates creation of the underlying system object
                           // is placed in mutexWasCreated.
                             //
                            _mutex = new Mutex(true, "GlobalsystemWideMutex", out 
                             mutexWasCreated, mSec);
    
                            if(!mutexWasCreated )
                            {
                                  //report error
                             }
                         } 
                        while (true)
                        {
                            try
                            {                       
                                bool acquired = _mutex.WaitOne(5000); //obtain a lock - timeout after n number of seconds
                                if(acquired)
                                {   
                                   try 
                                   {
                                      //DO THREADSAFE WORK HERE!!!
                                      //Write to the same file
                                   }
                                   catch (Exception e)
                                   {
                                     
                                   }  
                                   finally 
                                   {
                                      _mutex.ReleaseMutex(); //release
                                      break;
                                   }                          
                                }
                                else
                                {
                                   Thread.Sleep(1000); // wait for n number of seconds before retrying
                                } 
                            }
                            catch {  } //Create mutex for the first time
                           
                        }
                    }
                    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
                    {
                        try { _mutex.ReleaseMutex(); } catch { } //release
                    }
