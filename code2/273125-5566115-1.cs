    public class Consumer
    {
        private LockProvider provider;
        public void DoStufOnFile(string fileName)
        {
            lock (provider.GetLockObjectForKey(fileName))
            {
                // Long running operation on file here.
            }
        }
    }
