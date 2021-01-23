    public interface IRepositoryUser
    {
        IUser AddUser(String userName, String password, String email);
        IUser FindUser(String identifier);
    }
    
    public interface IRepositoryProduct
    {
        IProduct AddProduct(...);
        void RemoveProduct(...);
    }
    
    public interface IRepository : IRepositoryUser, IRepositoryProduct { }
