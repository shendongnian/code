    public class MyClass
    {
        ReaderWriterLockSlim rw = new ReaderWriterLockSlim();
        //You should explicitly stated that you want to use recursion
        ReaderWriterLockSlim rwWithRecursion = new ReaderWriterLockSlim (LockRecursionPolicy.SupportsRecursion);
    
        public void MethodA()
        {
            try {
               rw.EnterReadLock();
               // do something
               MethodB();
            }
            finally {
              rw.ExitReadLock();
            }
        }
    
        public void MethodB()
        {
            try {
               rw.EnterReadLock(); //throws LockRecursionException
            }
            finally {
              rw.ExitReadLock();
            }
        }
    }
