    internal class MutexOrRWLock
    {
        private const int LIMIT = 1000000;
        private const int WRITE = 100;//write once every n reads
        private static void Main()
        {
            if (Environment.ProcessorCount < 8)
                throw new ApplicationException("You must have at least 8 cores.");
            Process.GetCurrentProcess().ProcessorAffinity = new IntPtr(255); // pin the process to first 8 CPUs
            Console.WriteLine("ReaderWriterLock");
            new RWLockTest().Test(3);
            Console.WriteLine("ReaderWriterLockSlim");
            new RWSlimTest().Test(3);
            Console.WriteLine("Mutex");
            new MutexTest().Test(3);
        }
        private class RWLockTest : MutexTest
        {
            private readonly ReaderWriterLock _lock1 = new ReaderWriterLock();
            protected override void BeginRead() { _lock1.AcquireReaderLock(-1); }
            protected override void EndRead() { _lock1.ReleaseReaderLock(); }
            protected override void BeginWrite() { _lock1.AcquireWriterLock(-1); }
            protected override void EndWrite() { _lock1.ReleaseWriterLock(); }
        }
        private class RWSlimTest : MutexTest
        {
            private readonly ReaderWriterLockSlim _lock1 = new ReaderWriterLockSlim();
            protected override void BeginRead() { _lock1.EnterReadLock(); }
            protected override void EndRead() { _lock1.ExitReadLock(); }
            protected override void BeginWrite() { _lock1.EnterWriteLock(); }
            protected override void EndWrite() { _lock1.ExitWriteLock(); }
        }
        private class MutexTest
        {
            private readonly ManualResetEvent start = new ManualResetEvent(false);
            private readonly Dictionary<int, int> _data = new Dictionary<int, int>();
            public void Test(int count)
            {
                for (int i = 0; i < count; i++)
                {
                    _data.Clear();
                    for (int val = 0; val < LIMIT; val += 3)
                        _data[val] = val;
                        start.Reset();
                    Thread[] threads = new Thread[8];
                    for (int ti = 0; ti < 8; ti++)
                        (threads[ti] = new Thread(Work)).Start();
                    Thread.Sleep(1000);
                    Stopwatch sw = new Stopwatch();
                    sw.Start();
                    start.Set();
                    foreach (Thread t in threads)
                        t.Join();
                    sw.Stop();
                    Console.WriteLine("Completed: {0}", sw.ElapsedMilliseconds);
                }
            }
            protected virtual void BeginRead() { Monitor.Enter(this); }
            protected virtual void EndRead() { Monitor.Exit(this); }
            protected virtual void BeginWrite() { Monitor.Enter(this); }
            protected virtual void EndWrite() { Monitor.Exit(this); }
            private void Work()
            {
                int val;
                Random r = new Random();
                start.WaitOne();
                for (int i = 0; i < LIMIT; i++)
                {
                    if (i % WRITE == 0)
                    {
                        BeginWrite();
                        _data[r.Next(LIMIT)] = i;
                        EndWrite();
                    }
                    else
                    {
                        BeginRead();
                        _data.TryGetValue(i, out val);
                        EndRead();
                    }
                }
            }
        }
    }
