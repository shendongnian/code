    IDisposable disposableObject = InstantiateDisposable();
    bool error = true;
    try
    {
        DoWork(disposableObject);
        error = false; // if it gets to this line, no exception was thrown
    }
    catch (ReallyBadException e)
    {        
        throw new EvenWorseException("some message", e);
    }
    catch (Exception)
    {        
        throw;
    }
    finally
    {
        if (error) disposableObject.Dispose();
    }
