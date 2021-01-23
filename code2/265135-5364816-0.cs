    public bool DeviceCommand(Expression<Action> apiCallExp)
    {
        var methodCallExp = (MethodCallExpression) apiCallExp.Body;
        string methodName = methodCallExp.Method.Name;
        // do whatever you want with methodName
        Action apiCall = apiCallExp.Compile();
        try
        {
            apiCall();
        }
        catch(Exception exc)
        {
            LogException(exc);
            return false;
        }
        return true;
    }
