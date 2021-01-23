            private Object lockObject = new Object();
            private int threadCounter = 0;
            public int ThreadCounter
            {
                get
                {
                    lock(lockObject)
                    { 
                        return threadCounter;
                    } 
                }            
                set
                {
                    lock(lockObject)
                    { 
                        threadCounter = value;
                    } 
                }
            }
            //this should be a method
            if (ThreadCounter < 3)
            {
                ThreadCounter ++;
                new Thread(() => 
                {
                    Timer t = new Timer(() => EndThread(), null, 0, 20 * 60 * 1000);
                    while(threadIsRunning)
                    {                     
                         processEventLogTesting(/*somewhere in here code says ThreadCounter--*/;);
                    }
                }) {IsBackground = true }.Start();
            
                    }
                }
            }
            
            private void EndThread()
            {
                threadIsRunning = false;
            }
