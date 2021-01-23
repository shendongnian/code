    private List<Status> m_Log = new List<Status>();
    
    public ReadOnlyCollection<Status> Log {
        get {
            return m_Log.AsReadOnly();
        }
    }
