    public static PageData Instance
    {
        get
        {
            PageData instance = Thread.VolatileRead(ref m_Instance);
            if (instance == null)
            {
                lock (instanceLock)
                {
                    instance = Thread.VolatileRead(ref m_Instance);
                    if (instance == null)
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
        /* Setting to null to force the Instance to re-build */
        Thread.VolatileWrite(ref m_Instance, null);
        PageData pData = Instance;
    }
