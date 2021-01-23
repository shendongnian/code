    public class FileWriter
    {
        private ReadWriterLockSlim lock_ = new ReadWriterLockSlim();
        public void WriteData(/*....whatever */)
        {
            lock_.EnterWriteLock();
            try
            {
                // write your data here
            }
            finally
            {
                lock_.ExitWriteLock();
            }
        }
    } // eo class FileWriter
