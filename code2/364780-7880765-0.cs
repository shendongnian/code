    private static T GetObject<T>(int id) where T : class, IEntity     
    {
        using(var context = GetContext())
        {
            // What if you want to load relations as well?
            var entity = (from x in context.CreateObjectSet<T>()
                          where x.Id == id
                          select p).FirstOrDefault();
            // Typical issue - you cannot use neither eager, explicit or lazy 
            // loading
            context.Detach(entity);
            return entity;
        }
    }
    private static void UpdateObject<T>(T entity) where T : class, IEntity
    {
        using (var contex = GetContext())
        {
            // This works for POCOs but for EntityObject based entities you will have
            // to use your approach (combine it with GetObject method to load entity)
            context.Attach(entity);
            context.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
            context.SaveChanges();
        }
    }
    private static void DeleteObject<T>(int id) where T : class, IEntity, new()
    {
        using(var context = GetContext())
        {
            // You need only dummy entity with key to perform delete
            T entity = new T { Id = id };
            context.Attach(entity);
            context.DeleteObject(entity);
            context.SaveChanges();
        }
    }
    
