     public class Synchro
        {
            private Barrier _barrier;          
           
            public void Start(int numThreads)
            {
                _barrier = new Barrier((numThreads * 2)+1);
                for (int i = 0; i < numThreads; i++)
                {
                    new Thread(Method1).Start();
                    new Thread(Method2).Start(); 
                }
                new Thread(Method3).Start();
            }
            public void Method1()
            {
                //Do some work
                _barrier.SignalAndWait();
            }
            public void Method2()
            {
                //Do some other work.
                _barrier.SignalAndWait();
            }
            public void Method3()
            {
                _barrier.SignalAndWait();               
                //Do some other cleanup work.
            }
        }
