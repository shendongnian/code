    [System.Runtime.ExceptionServices.HandleProcessCorruptedStateExceptionsAttribute()]
    private void ThirdPartyCall()
    {
        try
        {
                return Call3rdPartyFunction()
        }
        catch (Exception exInstantiate)
        {
            ...
        }
    }
