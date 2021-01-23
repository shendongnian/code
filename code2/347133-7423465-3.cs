    class Repository<TEntity, TId> : IRepository<TEntity, TId> where TEntity : class{
        public TEntity FindById(TId id) {
            return _session.Get<TEntity>(id);
        }
    }
