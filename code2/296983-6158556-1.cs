    public class StaticOnlyClass{
        private int createdObjects;
        private static object staticLockObject = new object();
        public StaticOnlyClass()
        {
            lock(staticLockObject)
            {
                createdObjects++;
            }
        }
    }
