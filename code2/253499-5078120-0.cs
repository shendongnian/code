    class Example
    {
        SyncLock padlock = new SyncLock();
        
        void Method1
        {
            using (padlock.Lock())
            {
                // Now own the padlock
            }
        }      
        
        void Method2
        {
            using (padlock.Lock())
            {
                // Now own the padlock
            }
        }
    }
