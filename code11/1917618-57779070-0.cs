    IQueryable<M> entities = null;
    List<M> realEntities = null;
    using (var context = new DataContext("MySql", ConnectionString))  
    {
        entities = context.GetTable<M>();
        // materialize entities in scope of the context
        realEntities = entities.ToList();
    }
    return realEntities;
