     public static async Task<bool> SaveCustomerChangesToDb<TEntity>(DbContext context, TEntity objectToSave) where TEntity:class
        {
           context.Set<TEntity>().Add(objectToSave);
           await context.SaveChangesAsync();
           // some more logic...
           return true;
        }
