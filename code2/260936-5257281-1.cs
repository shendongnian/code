    public interface IRepositoryUser
    {
        IUser Add(String userName, String password, String email);
        IUser Find(String identifier);
    }
    
    public interface IRepositoryProduct
    {
        IProduct Add(...);
        void Remove(...);
    }
    
    public interface IRepository
    {
        IRepositoryUser User { get; }
        IRepositoryProduct Product { get; }
    }
