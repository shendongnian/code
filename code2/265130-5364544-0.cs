    public bool DeviceCommand(Action apiCall)
    {
        string methodName = apiCall.Method.Name;
        // do whatever you need to do with the methodName
        try
        {
            apiCall();
        }
        catch (Exception exc)
        {
            LogException(exc);
            return false;
        }        
        return true;
    }  
