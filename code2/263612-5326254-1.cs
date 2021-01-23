    public static PageData Instance
    {
        get
        {
            PageData instance;
            if (Thread.VolatileRead(ref instance) == null)
            {
                lock (instanceLock)
                {
                    if (Thread.VolatileRead(ref instance) == null)
                    {
                        instance = new PageData();
                        Thread.VolatileWrite(ref m_Instance, instance);
                    }
                }
            }
            return instance;
        }
    }
    public void ReSync()
    {                         
        lock (instanceLock)
        {
            /* Setting to null to force the Instance to re-build */
            Thread.VolatileWrite(ref m_Instance, null);
            PageData pData = Instance;
        }
    }
