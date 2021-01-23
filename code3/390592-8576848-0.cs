    public interface IService<T>
    {
        bool TableExists { get };
        void AddOrUpdate(T item);
        void Delete(T item);
        T Get(T item);
        T Get(string pk, string rk);
        // etc
    }
    public class AccountService : BaseService, IService<Account>
