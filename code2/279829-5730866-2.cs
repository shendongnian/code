    DisposableObject disposableObject = new DisposableObject();
    try
    {
        // do something with it
    }
    finally
    {
        if (disposableObject != null)
        {
            disposableObject.Dispose();
        }
    }
