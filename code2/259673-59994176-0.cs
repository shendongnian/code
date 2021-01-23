    lock(_lock)
    {
        try
        {
            using (TransactionScope tx = new TransactionScope(TransactionScopeOption.RequiresNew,
                            new TransactionOptions() { Timeout = new TimeSpan(0, 0, 10) }))
            {
                //do somenting important stuff
                tx.Complete();
                tx.Dispose();  // just remembering that will be disposed.
            }
        }
        catch (TransactionAbortedException tex)
        {
            throw new Exception("Operation Timeout");
        }
        catch (Exception)
        {
            throw; // do whatever you want
        }
    }
