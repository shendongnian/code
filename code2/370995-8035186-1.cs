    public class FileWriter
    {
        private ReaderWriterLockSlimlock lock_ = new ReaderWriterLockSlim();
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
