        public class RepositoryGeneric<TEntity>
        {
            public RepositoryGeneric(DomainContext domainContext)
            {
                DomainContext = domainContext;         
            }
    
            protected DomainContext DomainContext { get; private set; }
    
            protected virtual IDbSet<TEntity> DbSet
            {
                get { return DomainContext.Set<TEntity>(); }
            }
    
            public virtual TEntity GetByKey(params object[] keys)
            {
                return DbSet.Find(keys);
            }
       }
