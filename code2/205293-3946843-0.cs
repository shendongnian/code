    public string Version
    {
        get
        {
            return GetType().Assembly.GetName().Version.ToString(); 
        }
    }
