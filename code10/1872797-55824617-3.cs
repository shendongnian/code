    public SynchronizedReadOnlyCollection<int> pubReadOnlyProperty
    {
    	get
    	{
            lock (testlist.SyncRoot)
            {
                return new SynchronizedReadOnlyCollection<int>(testlist.SyncRoot, testlist);
            }
    	}
    }
 
