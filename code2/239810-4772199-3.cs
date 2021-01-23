    interface IUnitOfWork {
      void RegisterSave<TEntity>(TEntity entity);
      void RegisterRemove<TEntity>(TEntity entity);
      void RegisterUnitOfWork(IUnitOfWork uow);
      void Commit();
      void Rollback();
    }
