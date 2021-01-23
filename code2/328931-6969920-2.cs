    private static void Evict(DbContext ctx, Type t, 
        string primaryKeyName, object id)
    {            
        var cachedEnt =
            ctx.ChangeTracker.Entries().Where(x =>   
                ObjectContext.GetObjectType(x.Entity.GetType()) == t)
                .SingleOrDefault(x =>
            {
                Type entType = x.Entity.GetType();
                object value = entType.InvokeMember(primaryKeyName, 
                                    System.Reflection.BindingFlags.GetProperty, 
                                    null, x.Entity, new object[] { });
     
                return value.Equals(id);
            });
     
        if (cachedEnt != null)
            ctx.Entry(cachedEnt.Entity).State = EntityState.Detached;
    }
