    public class InstanceOnlyClass{
        private int callCount;
        private object lockObject = new object();
        public void CallMe()
        {
            lock(lockObject)
            {
                callCount++;
            }
         }
    }
