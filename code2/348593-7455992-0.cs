     public class Biz
        {
            public List<Customer> GetAllByName(string name)
            {
                return Repository.Find(x=>x.Name == name);
            }
        }
    
        public class Repository
        {
            private List<Customer> internalCustomerList = GetAllCustomers();
        
            public static IEnumerable< Find(Func<T, bool> predicate)
            {
                return internalCustomerList.Where(predicate);
            }
        }
