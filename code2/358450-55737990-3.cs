    IDisposable disposableObject = InstantiateDisposable();
    using (Disposer disposer = new Disposer(disposableObject))
    {
        try
        {
            DoWork(disposableObject);
            disposer.Cancel();
        }
        catch (ReallyBadException e)
        {
            throw new EvenWorseException("some message", e);
        }
    }
    // ... continue with disposableObject
