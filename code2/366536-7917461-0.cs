    public interface IBaseService
    {
        // all non-type-T related stuff
        IUnitOfwork UnitOfWork {get;}
    }
    
    public interface IBaseService<T> : IBaseService
    {
        // .. all type T releated stuff
    }
