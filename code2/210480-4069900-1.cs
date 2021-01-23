    public class MyThreadSafeClass
    {
        private readonly object lockObject = new object();
        private string mySharedString;
    
        public void ThreadSafeMethod(string newValue)
        {
            lock (lockObject)
            {
                // Once one thread has got inside this lock statement, any others will have to wait outside for their turn...
                mySharedString = newValue;
            }
        }
    }
