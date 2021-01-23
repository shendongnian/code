    ServiceController SC = new ServiceController("MyServiceName");
    bool ServiceIsInstalled = false;
    try
    {
        // actually we need to try access ANY of service properties
        // at least once to trigger an exception
        // not neccessarily its name
        string ServiceName = SC.DisplayName;
        ServiceIsInstalled = true;
    }
    catch (InvalidOperationException) { }
