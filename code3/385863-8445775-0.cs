    Task t = Task.Factory.StartNew(() => {
        response = ServiceManager.GeneralService.ServiceMethod(loginName, password);
    });
    try
    {
        t.Wait();
    }
    catch (AggregateException e)
    {
       ...
    }
