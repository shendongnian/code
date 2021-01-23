    private ApplicationDbContext(): base("ApplicationDbContext")
    {
    }
    
    
    public static ApplicationDbContext getInstance()
    {
        if (_instance == null)
        {
            _instance = new ApplicationDbContext();
        }
        return _instance;
    }
