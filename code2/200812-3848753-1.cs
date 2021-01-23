    DisposableType yourObj = new DisposableType();
    try
    {
        //contents of using block
    }
    finally
    {
        ((IDisposable)yourObj).Dispose();
    }
