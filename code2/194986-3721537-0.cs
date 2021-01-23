    public interface IRepository
    {
       public UnitOfWork BeginUnitOfWork()
       
       public void CommitUOW(UnitOfWork unit)
    
       public void RollBackUOW(UnitOfWork unit)
    
       public void GetAll<T>(UnitOfWork unit)
       public void Store<T>(T theObject, UnitOfWork unit)
    }
