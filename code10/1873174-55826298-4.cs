    public void M()
    {
        IDisposable disposable = CreateThing();
        try
        {
        }
        finally
        {
            if (disposable != null)
            {
                disposable.Dispose();
            }
        }
    }
