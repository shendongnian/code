    private static instanceLock = new object();
    private static _refreshing = true;
    
    public static PageData Instance
        {
            get
            {
                if (_refreshing)
                {
                    lock (instanceLock)
                    {
                        if (_refreshing)
                        {
                            m_Instance = new PageData();
                            refreshing = false; //now allow next refreshes.
                        }
                    }
                }
                return m_Instance;
            }
        }
    
    
    public void ReSync()
            {
                if (!_refreshing)                         
                    lock (instanceLock)
                    {
                        if (!_refreshing)
                        {
                            _refreshing = true; //don't allow refresh until singleton is called.
                        }
                    }
            }
