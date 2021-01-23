    public void Application_End()
    {
        lock (this)
        {
            if (kernel != null)
            {
                //kernel.Dispose();
                kernel = null;
            }
            this.OnApplicationStopped();
        }
    }
