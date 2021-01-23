    using (IDisposable disposableObject = InstantiateDisposable())
    {
        try
        {
            DoWork(disposableObject);
        }
        catch (ReallyBadException e)
        {
            throw new EvenWorseException("some message", e);
        }
    }
