    var myRes = new MyResource(); // where MyResource implements IDisposable
    try
    {
        myRes.DoSomething(); // this might throw an exception
    }
    finally
    {
        if (myRes != null)
        {
            ((IDisposable)myRes).Dispose();
        }
    }
