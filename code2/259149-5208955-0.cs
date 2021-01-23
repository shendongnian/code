    private readonly ReaderWriterLockSlim _myFieldLock = new ReaderWriterLockSlim();
    private long _myField;
    public long MyProperty
    {
        get 
    	{
    		_myFieldLock.EnterReadLock();
    		try
    		{
    			return _myField;
    		}
    		finally
    		{
    			_myFieldLock.ExitReadLock();
    		}
    	}
        set
    	{
    		_myFieldLock.EnterWriteLock();
    		try
    		{
    			_myField = value;
    		}
    		finally
    		{
    			_myFieldLock.ExitWriteLock();
    		}
    	}
    }
