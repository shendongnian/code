    public static PageData Instance
    {
        get
        {
            var instance = m_Instance;
            Thread.MemoryBarrier();
            if (instance == null)
            {
                lock (instanceLock)
                {
                    if (m_Instance == null)
                    {
                        instance = new PageData();
                        Thread.MemoryBarrier();
                        m_Instance = instance;
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
            m_Instance = null;
            PageData pData = Instance;
        }
    }
