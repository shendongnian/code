            static void Main(string[] args)
            {
                try
                {
                    Console.WriteLine("Main thread: " + System.Threading.Thread.CurrentThread.ManagedThreadId);
                    var observable = TestEnumerable().ToObservable(Scheduler.NewThread); //Needs to be on a new thread because it contains long-running blocking operations
    
                    // Use subject because we need many subscriptions to a single data source
                    var subject = new Subject<int>();
                    Exception exception = null;
                    ManualResetEvent mre = new ManualResetEvent(false);
                    
                    using(subject.Subscribe(
                        x => Console.WriteLine(x),
                        ex => { exception = ex; mre.Set(); },
                        () => Console.WriteLine("Subscriber2 Finished")))
                    using(subject.Subscribe(
                        x => Console.WriteLine(x),
                        ex => { exception = ex; mre.Set(); },
                        () => Console.WriteLine("Subscriber2 Finished")))
                    using (observable.Subscribe(subject))
                    {
                        mre.WaitOne();
                    }
    
                    if (exception != null)
                        throw exception;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Caught exception on main thread");
                }
    
            }
