    public interface IRepository<TItem>
    {       
        TItem GetEntity(int id);
    }
    
    public interface IUserRepository : IRepository<User>
    {   
    }
    
    public interface IUnitOfWork
    {
        TRepo Respository<TRepo,TItem>() where TRepo : IRepository<TItm>;
    }
