    DisposableObject disposableObject;
    try
    {
        disposableObject = new DisposableObject();
        // do something with it
    }
    finally
    {
        if (disposableObject != null)
        {
            disposableObject.Dispose();
        }
    }
