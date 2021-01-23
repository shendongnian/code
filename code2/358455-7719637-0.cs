    public IEnumerable<StackUserDataModel> Select() 
    {
        try
        {
            ...
        }
        catch (StorageClientException e)
        {
           // You could do this if there is no fancy processing to do
           if (!IsCatchableException(e))
              throw;
        }
    }
    bool IsCatchableException(StorageClientException e)
    {
        ... optionally do some fancy processing of the exception, e.g. logging....
        switch (e.ErrorCode)
        {
            case StorageErrorCode.AccessDenied:
            case StorageErrorCode.AccountNotFound:
            ....
            return true;
        }
    }
