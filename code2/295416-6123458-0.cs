    private ReaderWriterLockSlim dataLock = new ReaderWriterLockSlim();
    
    public SomeDataObject DataA
    {
        get
        {
            if (dataAisAvailable)
            {
                return dataA;
            }
    
            dataLock.EnterReadLock();
    
            try
            {
                if (dataBisAvailable)
                {
                    dataLock.EnterUpgradeableReadLock();
    
                    try
                    {
                        // Don't want other threads recalculating dataA
                        if (dataAisAvailable)
                        {
                            return dataA;
                        }
    
                        dataLock.EnterWriteLock();
                        try
                        {
                            ////////////////////////////////
                            // Calculate dataA from dataB //
                            ////////////////////////////////
    
                            dataAisAvailable = true;
                        }
                        finally
                        {
                            dataLock.ExitWriteLock();
                        }
    
                        return dataA;
                    }
                    finally
                    {
                        dataLock.ExitUpgradeableReadLock();
                    }
                }
                else
                {
                    return null;
                }
            }
            finally
            {
                dataLock.EnterReadLock();
            }
        }
    }
