    public class StaticAndInstanceClass{
        private int createdObjects;
        private static object staticLockObject = new object();
        private int callCount;
        private object lockObject = new object();
        public StaticAndInstanceClass()
        {
            lock(staticLockObject)
            {
                createdObjects++;
            }
        }
        public void CallMe()
        {
            lock(lockObject)
            {
                callCount++;
            }
         }
    }
