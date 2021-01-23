    try
    {
        DerivedComponent c = obj.RandomComponent;
        return c;
    }
    catch (Microsoft.CSharp.RuntimeBinder.RuntimeBinderException)
    {
        // do something here...
    }
    catch (InvalidCastException)
    {
        // handle error
    }
