    namespace SomeNamespace.SomeSubNamespace
    {
        class SomeClass
        {
            void SomeFunction()
            {
                using (var someFile = new StreamWriter(somePath))
                try
                {
                    lock(someCriticalSection)
                    {
                        using (var someDisposableThing1 = new DisposableThing())
                        using (var someDisposableThing2 = new DisposableThing())
                        {
                            DoSomething();                            
                            DoSomethingMore();
                        }
                    }
                }
                catch(Exception e)
                {
                    Log(e);
                }
            }
        }
    }
