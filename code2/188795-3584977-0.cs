    namespace SomeNamespace.SomeSubNamespace
    {
        class SomeClass
        {
            void SomeFunction()
            {
                StreamWriter someFile = new StreamWriter(somePath);
                DisposableThing someDisposableThing1 = null;
                DisposableThing someDisposableThing2 = null;
    
                try
                {
                    lock (someCriticalSection)
                    {
                        someDisposableThing1 = new DisposableThing();
                        DoSomething();
                        someDisposableThing2 = new DisposableThing();
                        lock (someOtherCriticalSection)
                        {
                            DoSomethingMore();
                        }
                    }
                }
                catch (Exception e)
                {
                    Log(e);
                }
                finally
                {
                    // requires SafeDispose extension method
                    someFile.SafeDispose();
                    someDisposableThing1.SafeDispose();
                    someDisposableThing2.SafeDispose();
                }
            }
        }
    }
