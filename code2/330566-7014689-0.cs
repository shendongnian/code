    Dictinary<Guid, DataSet> serverCache = new Dictionary<Guid, DataSet>;
    This.ApplicationState.Add(serverCache, "DataCache");
    // Add users session key and local cached data here
    serverCache.Add(This.GetUserSessionGuid(), This.LoadData());
    
