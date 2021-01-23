        public class ThreadAQueue
        {
            private Queue<delegate> _queue;
            private bool _quitWorking;
            public void EnqueueSomeWork(delegate work)
            {
                lock(_queue) 
                {
                    _queue.Enqueue(work);
                }
            }
            
            private void DoTheWork()
            {
                while(!quitWorking) 
                {
                    delegate myWork;
                    
                    lock(_queue)
                    {
                        if(_queue.Count > 1)
                            myWork = _queue.Dequeue();
                    }
                
                    myWork();
                }
            }
        }
