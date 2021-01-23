    using (TransactionScope scope = new TransactionScope())
    {
        MyDbContext context = null;
        try
        {
            context = new MyDbContext();
            context.Configuration.AutoDetectChangesEnabled = false;
            int count = 0;            
            foreach (var entityToInsert in someCollectionOfEntitiesToInsert)
            {
                ++count;
                context = AddToContext(context, entityToInsert, count, 100, true);
            }
        
            context.SaveChanges();
        }
        finally
        {
            if (context != null)
                context.Dispose();
        }
        scope.Complete();
    }
    private MyDbContext AddToContext(MyDbContext context,
        Entity entity, int count, int commitCount, bool recreateContext)
    {
        context.Set<Entity>().Add(entity);
        if (count % commitCount == 0)
        {
            context.SaveChanges();
            if (recreateContext)
            {
                context.Dispose();
                context = new MyDbContext();
                context.Configuration.AutoDetectChangesEnabled = false;
            }
        }
        return context;
    }
