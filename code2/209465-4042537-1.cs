    IDisposable someDisposable = new ...
    IDisposable someDisposable2 = someDisposable ;
    try
    {
        // your code with someDisposable 
    }
    finally
    {
        if (someDisposable2 != null)
        {
            someDisposable2.Dispose();
        }
    }
