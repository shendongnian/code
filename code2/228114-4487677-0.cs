    // With a lambda
    private void OnFormLoad()
    {
        ThreadPool.QueueUserWorkItem(() => GetSqlData()); 
    }
    // Without a lambda
    private void OnFormLoad() 
    { 
        ThreadPool.QueueUserWorkItem(ExecuteGetSqlData);
    }
    private void ExecuteGetSqlData()
    {
        // If GetSqlData returns something, change this to "return GetSqlData();"
        GetSqlData();
    }
