        public interface IService<T, TDetail, TSummary>
        {
            void AddOrUpdate(T account);
            void Delete(T account);
            bool DoesTableExist();
            T Get(T account);
            T Get(string pk, string rk);
            IEnumerable<T> Get();
            IEnumerable<T> Get(string pk);
            string GetOptions(string pk, string rk);
            IEnumerable<TDetail> ShowDetails(ref string runTime);
            IEnumerable<TSummary> ShowSummary(ref string runTime);
            void ValidateNoDuplicate(T account);
            void ValidateNoProducts(T account);
        }
     
        public class AccountService : BaseService, IService<Account, AccountDetail, AccountSummary>
        public class ProductService : BaseService, IService<Product, ProductDetail, ProductSummary>
        public class PackageService : BaseService, IService<Package, PackageDetail, PackageSummary>
