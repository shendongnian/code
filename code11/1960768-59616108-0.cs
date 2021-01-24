    public class StoreManager
    {
         public StoreManager( Context context )
         {
             this.context = context;
         }
       public TEntity Add(TEntity entity)
       {
            var addedEntity = context.Entry(entity);
            addedEntity.State = EntityState.Added;
            context.SaveChanges();
            return entity;
        }
    }
