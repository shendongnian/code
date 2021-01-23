    // Create one of these
    interface IUnitOfWork
    {
        void Commit();
    }
    // Create one of these
    interface IEntitySet<TEntity> where TEntity : class
    {
        void Add(TEntity entity);
        void Remove(TEntity entity);
        TEntity Create<TSpecificEntity>() where TSpecificEntity : TEntity;
        IQueryable<TEntity> Query();
    }
    // Create one of these per entity type
    interace IEntitySetOfTEntity1 : IEntitySet<Entity1>
    {
        TEntity1 GetByKeys(int key1);
    }
    interace IEntitySetOfTEntity2 : IEntitySet<Entity2>
    {
        TEntity1 GetByKeys(short key1, short key2);
    }
    // Create one of these per separatable domain
    interface IDomain1UnitOfWork : IUnitOfWork
    {
        IEntitySetOfTEntity1 Entity1s
        {
            get;
        }
        IEntitySetOfTEntity2 Entity2s
        {
            get;
        }
    }
