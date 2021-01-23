    public interface IService<T>
    {
        void AddOrUpdate(T entity);
        void Delete(T entity);
        bool DoesTableExist();
        T Get(T entity);
        T Get(string pk, string rk);
        IEnumerable<T> Get();
        IEnumerable<T> Get(string pk);
        string GetOptions(string pk, string rk);
        IEnumerable<AccountDetail> ShowDetails(ref string runTime); // you will need to redisign this part
        IEnumerable<AccountSummary> ShowSummary(ref string runTime); //same for this method
        void ValidateNoDuplicate(T account);
        void ValidateNoProducts(T account);
    }
