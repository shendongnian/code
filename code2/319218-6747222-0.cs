    try
    {
        MyAddIn = Token.Activate<AddInHostView>(domain);
    }
    catch (Exception ex)
    {
        try
        {
            AppDomain.Unload(domain);
            domain = null;
        }
        catch (ThreadAbortException threadAbortException)
        {
            //ToDo: Logging
        }
        catch (CannotUnloadAppDomainException cannotUnloadAppDomainException)
        {
            //ToDo: Logging
        }
        catch (Exception exception)
        {
            //ToDo: Logging
        }
    }
