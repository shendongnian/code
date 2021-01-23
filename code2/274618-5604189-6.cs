    public static void DynamicUsing(object resource, Action action)
    {
        try
        {
            action();
        }
        finally
        {
            IDisposable d = resource as IDisposable;
            if (d != null)
                d.Dispose();
        }
    }
