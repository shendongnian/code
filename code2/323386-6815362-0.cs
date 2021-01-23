    class MyClass
    {
        public void DoSomethingCore()
        {
            lock(this)
            {
                // You never know if you will be able to get in here.
                // Maybe another thread has locked this instance before
                // this method was called on the current thread.
            }
        }
    }
    
    static class Utility
    {
        public static void DoSomething(MyClass obj)
        {
            lock(obj)
            {
                // The line below will cause a deadlock if you call it on another
                // thread, because this thread already holds a lock on obj.
                // If you just call it on the current thread (as I do here) there
                // will not be a deadlock (this is because Monitor.Enter will let
                // the thread "re-acquire" any locks it already holds).
                obj.DoSomethingCore();
    
                // plus more operations that need to be synced
            }
        }
    }
