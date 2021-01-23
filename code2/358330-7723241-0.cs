    public class UserService : IUserService
    {
        public bool Approve(User usr)
        {
            throw new NotImplementedException();
        }
        public User Add(User Entity)
        {
            throw new NotImplementedException();
        }
        public User Remove(User Entity)
        {
            throw new NotImplementedException();
        }
        public IQueryable<User> GetAll()
        {
            throw new NotImplementedException();
        }
    }
    public class User { }
    public interface IRepository<T>
    {
        T Add(T Entity);
        T Remove(T Entity);
        IQueryable<T> GetAll();
    }
    public interface IUserService : IRepository<User>
    {
        bool Approve(User usr);
    }
