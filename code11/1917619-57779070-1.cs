    using (var context = new DataContext("MySql", ConnectionString))  
    {
        entities = context.GetTable<M>();
        // you can apply Where filter here, it won't trigger the materialization.
        entities = entities.Where(e => e.Quantity > 50);
        // what exactly happens there: 
        // 1. Data from the M table is filtered
        // 2. The filtered data only is retrieved from the database
        //    and stored in the realEntities variable (materialized).
        realEntities = entities.ToList();
    }
