    public interface IRepository<T> : IDisposable where T : class, IDomainObject
    {
        IUnitOfWork BeginUnitOfWork();
        void CommitUnitOfWork(IUnitOfWork unitOfWork);
        void RollBackUnitOfWork(IUnitOfWork unitOfWork);        
        void Save(T domainObject, IUnitOfWork unitOfWork);        
        IQueryable<T> QueryFor(IUnitOfWork unitOfWork);
    }
