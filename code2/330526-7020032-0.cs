    try
    {
        DoSomething();
    }
    catch (Exception ex)
    {
        ex.Data["ExecutingAssembly"] = Assembly.GetExecutingAssembly().FullName;
        bool rethrow = exceptionManager.HandleException(ex, "LogException");
        if (rethrow)
        {
            throw;
        }
    }
