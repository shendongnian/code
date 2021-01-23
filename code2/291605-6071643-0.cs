    // Execute    
    IEnumerable<MainEntity> result = context.ExecuteStoreQuery<MainEntity>(strQuery, "MainEntities", MergeOption.AppendOnly, someParams).ToArray();
    // Load relations, first method
    foreach (MainEntity e in result)
    {
        if (!e.Relation1Reference.IsLoaded)
            e.Relation1Reference.Load();
        if (!e.Relation2Reference.IsLoaded)
            e.Relation2Reference.Load();
        // ...
    }
    // Load relations, second method
    // The main entity contains a navigation property pointing 
    // to a record in the OtherEntity entity
    foreach(OtherEntity e in context.OtherEntities)
        context.OtherEntities.Attach(e);
