    EntityA aAlias = null;
    EntityB bAlias = null;
    // Build the base query, joining all the tables that you may need
    var query = session.QueryOver<EntityA>(() => aAlias)
        .JoinAlias(() => aAlias.ListOfB, () => bAlias);
    
    // Add conditions depending on your requirements, e.g. filter criteria passed from an external source
    if (expression1) 
    {
        query = query.Where(aAlias.SomeId == someId);
    }
    if (expression2) 
    {
        query = query.WhereRestrictionOn(() => bAlias.SomeOtherId).IsIn(listOfIds)
    }
    // and so on...
    // at the end, just execute the query to get a list of strings or whatever you want
    var result = query
        .Select(x => aAlias.Id)
        .List<string>();
