    if (myLock.TryEnter(0))
    {
        try
        {
            // process
        }
        finally
        {
            myLock.Exit();
        }
    }
