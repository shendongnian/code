    try
    {
        service.DoSomething("someParameter");
        if (service.GetSomeStatus())
        {
        }
    }
    finally
    {
        (service as IDisposable).Dispose();
    }
