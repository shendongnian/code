    public bool Log { get; set; }
    string logFilePath;
    public string LogFilePath
    {
        get { return logFilePath; }
        set 
        {
            logFilePath = ValidateLogFilePath(value);
            Log = logFilePath.Length > 0;
        }            
    }
    public void WriteLine(string line)
    {
        if (!Log)
            return;
        //...
    }
