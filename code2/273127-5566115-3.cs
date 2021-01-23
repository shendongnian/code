    public class Consumer
    {
        private LockProvider provider;
        public void DoStufOnFile(string fileName)
        {
            using (ILocker locker =
                this.provider.GetLockObjectForKey(fileName))
            {
                // A using statement is not as 'strong' as a lock, so
                // we need to call Enter within the using statement.
                locker.Enter();
            
                // Long running operation on file here.
            }
        }
    }
