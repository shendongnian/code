    Heartbeat()
    {
        var orgResult = GetOrgs()
        var spaceResult = GetSpace()
        var appResult = GetApps()
    
        var dbContext = blah()
    
        dbContext.Add(orgResult)
        dbContext.Add(spaceResult)
        dbContext.Add(appResult)
    
        dbContext.SaveAllThatStuff()
    }
