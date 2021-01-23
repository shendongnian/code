    {
        IDisposable xxx = new MyObject();
        try
        {
            ....
        }
        finally
        {
            if (xxx != null)
                xxx.Dispose();
        }
    }
