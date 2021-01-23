    Result result = new Result();
    try
    {
        result = FTPRename(some parameters...);
        result = FTPDownloadAndCopy(some parameters...);
        result = FTPMove(some parameters...);
        result = FTPDelete(some parameters...);
    }
    catch (SomeException e)
    {
        return (object[])new object[] { par as ThreadCounterManager, result.SetError(e.Message) };
    }
    
    return return (object[])new object[] { par as ThreadCounterManager, result };
