    public static void ExecuteAsyncLoop(Func<bool> loopBody)
    {
        loopBody.BeginInvoke(ExecuteAsyncLoop, loopBody);
    }
    private static void ExecuteAsyncLoop(IAsyncResult result)
    {
        var func = ((Func<bool>)result.AsyncState);
        try
        {
            if (!func.EndInvoke(result))
                return;
        }
        catch
        {
            // Do something with exception.
            return;
        }
        func.BeginInvoke(ExecuteAsyncLoop, func);
    }
