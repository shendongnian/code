    IDisposable disposable = InstantiateDisposable();
    try
    {
        try
        {
            DoWork(disposable);
        }
        catch (Exception)
        {
            disposable.Dispose();
            throw;
        }
    }
    catch (ReallyBadException ex)
    {
        throw new EvenWorseException("some message", ex);
    }
