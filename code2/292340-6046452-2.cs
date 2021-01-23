    public void Method1()
    {
        Action action = () =>
        {
            // actual processing of Method 1
        };
        SafeExecutor(action);
    }
    public void Method1b()
    {
        SafeExecutor(() =>
        {
            // actual processing of Method 1
        });
    }
    public void Method2(int someParameter)
    {
        Action action = () =>
        {
            // actual processing of Method 2 with supplied parameter
            if(someParameter == 1)
            ...
        };
        SafeExecutor(action);
    }
    public int Method3(int someParameter)
    {
        Func<int> action = () =>
        {
            // actual processing of Method 3 with supplied parameter
            if(someParameter == 1)
                return 10;
            return 0;
        };
        return SafeExecutor(action);
    }
    private void SafeExecutor(Action action)
    {
        SafeExecutor(() => { action(); return 0; });
    }
    private T SafeExecutor<T>(Func<T> action)
    {
        try
        {
            return action();
        }
        catch (FaultException<CustomException> cfex)
        {
            // common stuff
        }
        catch (CustomException cfex)
        {
            // common stuff
        }
        catch (Exception ex)
        {
            // common stuff
        }
        finally
        {
            FinalizeServiceCall(wsBus, wsMessage, response, logProps);
        }
        return default(T);
    }
