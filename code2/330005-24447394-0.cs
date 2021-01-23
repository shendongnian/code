    clientContext.Credentials = credentials;
           clientContext.Load(site);
           clientContext.ExecuteQuery();
    
    clientContext.Credentials = credentials;
           clientContext.Load(list);
           clientContext.ExecuteQuery();
