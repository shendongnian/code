    interface ISet<TEntity> : IQueryable<TEntity> where TEntity: IRepositoryEntity
    {
         TEntity Add(TEntity item);
    }
    class Set<TEntity, TDbEntity> : ISet<TEntity>
      where TEntity: IRepositoryEntity,
      where TDbEntity: IDbItem
    {
         public IDbSet<TEntity> DbSet {get; set;}
         // implement the interfaces via DbSet
         public TEntity Add(TEntity item)
         {
             // TODO: convert item to a dbItem
             return this.DbSet.Add(dbItem);
         }
         // Similar for IQueryable<TEntity> and IQueryable
    }
