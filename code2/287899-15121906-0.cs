    public void AddAndSave<TEntity>(List<TEntity> entities) where TEntity : class {
    const int CommitCount = 1000; //set your own best performance number here
    int currentCount = 0;
    while (currentCount < entities.Count())
    {
        //make sure it don't commit more than the entities you have
        int commitCount = CommitCount;
        if ((entities.Count - currentCount) < commitCount)
            commitCount = entities.Count - currentCount;
        //e.g. Add entities [ i = 0 to 999, 1000 to 1999, ... , n to n+999... ] to conext
        for (int i = currentCount; i < (currentCount + commitCount); i++)        
            Add<TEntity>(entities[i]);        
        //commit entities[n to n+999] to database
        _context.SaveChanges();
        //detach all entities in the context that committed to database
        //so it won't overload the context
        for (int i = currentCount; i < (currentCount + commitCount); i++)
            _context.Entry(entities[i]).State = System.Data.EntityState.Detached;
        currentCount += commitCount;
    } }
