    public static int GetVersion<T>(this List<T> list)
    {
        return (int)list.GetType()
                        .GetField("_version", BindingFlags.Instance | BindingFlags.NonPublic)
                        .GetValue(list);
    }
    ...
    
    private int _lastCheckedVersion = 0;
    
    private void Update()
    {
        int currentVersion = ourList.GetVersion();
          
        if(currentVersion != _lastCheckedVersion) CheckList(ourList);
     
        _lastCheckedVersion = currentVersion;
    }
