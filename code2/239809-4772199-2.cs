    interface IRepository<TEntity, in TKey> where TEntity : IAggregate<TKey> {
      TEntity Get(TKey id);
      void Save(TEntity entity);
      void Remove(TEntity entity);
    }
