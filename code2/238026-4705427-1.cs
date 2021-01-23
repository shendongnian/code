    public class PrioritisedLock
    {
        private List<CountdownEvent> waitQueue; //wait queue for the shared resource
        private Semaphore waitQueueSemaphore; //ensure safe access to wait queue itself
        
        public PrioritisedLock()
        {
            waitQueue = new List<CountdownEvent>();
            waitQueueSemaphore = new Semaphore(1, 1);
        }
        
        public bool WaitOne(int position = 0)
        {
            //CountdownEvent needs to have a initial count of 1
            //otherwise it is created in signaled state
            position++;
            bool containsGrantedRequest = false; //flag to check if wait queue still contains object which owns the lock
            CountdownEvent thisRequest = position<1 ? new CountdownEvent(1) : new CountdownEvent(position);
            
            waitQueueSemaphore.WaitOne();
            
            //insert the request at the appropriate position
            foreach (CountdownEvent cdEvent in waitQueue)
            {
                if (cdEvent.CurrentCount > position)
                    cdEvent.AddCount();
                else if (cdEvent.CurrentCount == position)
                    thisRequest.AddCount();
                
                if (cdEvent.CurrentCount == 0)
                    containsGrantedRequest = true;
            }
            waitQueue.Add(thisRequest);
            
            //If nobody holds the lock, grant the lock to the current request
            if (containsGrantedRequest==false && thisRequest.CurrentCount == 1)
                thisRequest.Signal();
            
            waitQueueSemaphore.Release();
            
            //now do the actual wait for this request; if it is already signaled, it ends immediately
            thisRequest.Wait();
            return true;
        }
        
        public int Release()
        {
            int waitingCount = 0, i = 0, positionLeastMagnitude=Int32.MaxValue;
            int grantedIndex = -1;
            
            waitQueueSemaphore.WaitOne();
            foreach(CountdownEvent cdEvent in waitQueue)
            {
                if (cdEvent.CurrentCount <= 0)
                {
                    grantedIndex = i;
                    break;
                }
                i++;
            }
            
            //remove the request which is already fulfilled
            if (grantedIndex != -1)
                waitQueue.RemoveAt(grantedIndex);
            //find the wait count of the first element in the queue
            foreach (CountdownEvent cdEvent in waitQueue)
                if (cdEvent.CurrentCount < positionLeastMagnitude)
                    positionLeastMagnitude = cdEvent.CurrentCount;
            //decrement the wait counter for each waiting object, such that the first object in the queue is now signaled
            foreach (CountdownEvent cdEvent in waitQueue)
            {
                waitingCount++;
                cdEvent.Signal(positionLeastMagnitude);
            }
            waitQueueSemaphore.Release();
            return waitingCount;
        }
    }
}
