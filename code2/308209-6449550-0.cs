    try
    { 
        ObjectFactory.ReleaseAndDisposeAllHttpScopedObjects();
    }
    catch(Exception E)
    {
        new HybridLifecycle().FindCache().DisposeAndClear();
    }
