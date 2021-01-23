    class Puzzle
    {
        private List<string> listOfStrings = new List<string>();
        private ReadWriterLockSlim listLock = new ReadWriterLockSlim();
    
        public void Add(string item)
        {
            listLock.EnterWriteLock();
    
            try
            {
                listOfStrings.Add(item);
            }
            finally
            {
                listlock.ExitWriteLock();
            }
        }
    
        public override string ToString()
        {
            listLock.EnterReadLock();
    
            try
            {
                return string.Join(",", listOfStrings);
            }
            finally
            {
                listLock.ExitReadLock();
            }
        }
    }
