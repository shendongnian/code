     System.Threading.Mutex _mutex = null;
                public Form1()
                {
                    new Thread(threadSafeWorkBetween2Instances).Start();
                }
                void threadSafeWorkBetween2Instances()
                {
                   //OpenExisting will create the mutex if it doesn't already exist
                    _mutex = System.Threading.Mutex.OpenExisting("GlobalsystemWideMutex");
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
