    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Threading;
    internal sealed class Program
    {
        private static void Main(string[] args)
        {
            int threadCount = 2;
            using (ThreadData data = new ThreadData(threadCount))
            {
                Thread[] threads = new Thread[threadCount];
                for (int i = 0; i < threadCount; ++i)
                {
                    threads[i] = new Thread(DoOperations);
                }
                foreach (Thread thread in threads)
                {
                    thread.Start(data);
                }
                Console.WriteLine("Starting...");
                // Start and wait here while all work is dispatched.
                data.RunDispatcher();
            }
            // Dispatcher has exited.
            Console.WriteLine("Shutdown.");
        }
        private static void DoOperations(object objData)
        {
            ThreadData data = (ThreadData)objData;
            try
            {
                // Start scheduling operations from child thread.
                for (int i = 0; i < 5; ++i)
                {
                    int t = Thread.CurrentThread.ManagedThreadId;
                    int n = i;
                    data.ExecuteTask(() => SayHello(t, n));
                }
            }
            finally
            {
                // Child thread is done.
                data.OnThreadCompleted();
            }
        }
        private static void SayHello(int requestingThreadId, int operationNumber)
        {
            Console.WriteLine(
                "Saying hello from thread {0} ({1}) on thread {2}.",
                requestingThreadId,
                operationNumber,
                Thread.CurrentThread.ManagedThreadId);
        }
        private sealed class ThreadData : IDisposable
        {
            private readonly Dispatcher dispatcher;
            private readonly TaskScheduler scheduler;
            private readonly TaskFactory factory;
            private readonly CountdownEvent countdownEvent;
            // In this example, we initialize the countdown event with the total number
            // of child threads so that we know when all threads are finished scheduling
            // work.
            public ThreadData(int threadCount)
            {
                this.dispatcher = Dispatcher.CurrentDispatcher;
                SynchronizationContext context = 
                    new DispatcherSynchronizationContext(this.dispatcher);
                SynchronizationContext.SetSynchronizationContext(context);
                this.scheduler = TaskScheduler.FromCurrentSynchronizationContext();
                this.factory = new TaskFactory(this.scheduler);
                this.countdownEvent = new CountdownEvent(threadCount);
            }
            // This method should be called by a child thread when it wants to invoke
            // an operation back on the main dispatcher thread.  This will block until
            // the method is done executing.
            public void ExecuteTask(Action action)
            {
                Task task = this.factory.StartNew(action);
                task.Wait();
            }
            // This method should be called by threads when they are done
            // scheduling work.
            public void OnThreadCompleted()
            {
                bool allThreadsFinished = this.countdownEvent.Signal();
                if (allThreadsFinished)
                {
                    this.dispatcher.InvokeShutdown();
                }
            }
            // This method should be called by the main thread so that it will begin
            // processing the work scheduled by child threads. It will return when
            // the dispatcher is shutdown.
            public void RunDispatcher()
            {
                Dispatcher.Run();
            }
            public void Dispose()
            {
                this.Dispose(true);
                GC.SuppressFinalize(this);
            }
            // Dispose all IDisposable resources.
            private void Dispose(bool disposing)
            {
                if (disposing)
                {
                    this.countdownEvent.Dispose();
                }
            }
        }
    }
