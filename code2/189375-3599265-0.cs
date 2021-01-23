    try
    {
         registrator.Method.Invoke(instance, parameters);
    }
    catch (TargetInvocationException tie)
    {
        // replace IOException with the exception type you are expecting
        if (tie.InnerException is IOException)
        {
            registrator.FailureType = RegistratorFailureType.ExceptionInRegistrator;
            registrator.Exception = tie.InnerException;
        }
        else
        {
            // decide what you want to do with all other exceptions — maybe rethrow?
            throw;
            // or maybe unwrap and then throw?
            throw tie.InnerException;
        }
    }
