    SomeDisposableResource resource = new SomeDisposableResource();
    try
    {
        // TODO: use the resource
    }
    finally
    {
        if (resource != null)
        {
            ((IDisposable)resource).Dispose();
        }
    }
