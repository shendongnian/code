    public Match(int matchId) 
    {
        // You called constructor yourselves = you have unproxied entity without
        // dynamic change tracking and without lazy loading
        Id = matchId;
        // I'm not sure if this is possible in entity constructor but generally it should work
        // Get context somewhere - service locator pattern
        ObjectContext context = ContextProvider.GetCurrent();
        context.Matches.Attach(this);
        context.Refresh(RefreshMode.StoreWins, this);
        // Now you should have populated Match entity itself but not its navigation properties
        // To populate relations you must call separate query for each of them because `Include`
        // is possible only when the entity is created and loaded by EF and lazy loading is off
        // in this case
        context.LoadProperty(this, m => m.TeamA);
        context.LoadProperty(this, m => m.TeamB);
        
        Season = (from s in context.Seasons.Include("Competition")
                  select s).ToList();      
    }
