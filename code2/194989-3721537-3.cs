    public interface IRepository
    {
       public UnitOfWork BeginUnitOfWork()
       
       public void CommitUOW(UnitOfWork unit)
    
       public void AbortUOW(UnitOfWork unit)
    
       public IQueryable<T> GetAll<T>(UnitOfWork unit)
       public List<T> GetAll<T>()
       public void Store<T>(T theObject, UnitOfWork unit)
       public void Store<T>(T theObject)
    }
