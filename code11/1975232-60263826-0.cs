    class LockProgram
    {
        static ReaderWriterLockSlim rwLock = new ReaderWriterLockSlim();
        static void Main(string[] args)
        {
            for (int i = 0; i < 2; i++)
            {
                Task.Factory.StartNew(Read);
            }
            for (int i = 0; i < 1; i++)
            {
                Task.Factory.StartNew(Write);
            }
            Console.Read();
        }
        static void Read()
        {
            while (true)
            {
                rwLock.EnterReadLock(); ;                
                Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}  reading");
                rwLock.ExitReadLock();
                Thread.Sleep(100);
            }
        }
        static void Write()
        {
            while (true)
            {
                rwLock.EnterWriteLock();                
                Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} writing");
                rwLock.ExitWriteLock();
                Thread.Sleep(3000);
            }
        }
    }
