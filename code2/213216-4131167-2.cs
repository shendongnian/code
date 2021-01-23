    public class NhRepository<T> : IRepository<T>
    {
        public T Get(int id)
        {
            return GetSession().Get<T>(id);
        }
    }
    public interface IUserRepository : IRepository<User>
    {
        IEnumerable<User> GetActiveUsers();
    }
    public class UserRepository : NhRepository<User>, IUserRepository
    {
        public IEnumerable<User> GetActiveUsers()
        {
            return
                from user in GetSession().Users
                where user.IsActive
                return user;
        }
    }
