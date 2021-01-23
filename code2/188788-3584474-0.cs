    namespace SomeNamespace.SomeSubNamespace
    {
        class SomeClass
        {
            void SomeFunction()
            {
                StreamWriter someFile;
                try
                {
                    someFile = new StreamWriter(somePath);
                    lock(someCriticalSection)
                    {
                        using (var someDisposableThing1 = new DisposableThing())
                        {
                            DoSomething();                            
                            using (var someDisposableThing2 = new DisposableThing())
                            {
                                lock(someOtherCriticalSection)
                                {
                                    DoSomethingMore();
                                }
                            }
                        }
                    }
                }
                catch(Exception e)
                {
                    Log(e);
                }
                finally
                {
                    if( someFile != null )
                    {
                         someFile.Dispose();
                    }
                }
            }
        }
    }
