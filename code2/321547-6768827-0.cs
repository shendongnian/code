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
            private Timer[] timer = new Timer[3];
            if (ThreadCounter < 3)
            {
                ThreadCounter ++;
                for (int i = 0; i < 3; i++)
                {
                    new Thread(() => 
                    {
                        timer[ThreadCounter] = new Timer(() => EndThread(), null, 0, 20 * 60 * 1000);
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
